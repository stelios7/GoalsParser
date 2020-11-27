using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System.IO;
using System.Globalization;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Threading;

namespace GoalsParser
{
     public partial class MainForm : Form
     {
          #region DECLARATIONS
          public enum wMode { Write, Append }
          /// <remarks>
          /// Concurrent Dictionary to hold games scraped from TZIROS page
          /// </remarks>
          public static ConcurrentDictionary<string, Game> dTziros = new ConcurrentDictionary<string, Game>();
          /// <remarks>
          /// Concurrent Dictionary to hold games scraped from COUPON page
          /// </remarks>
          public static ConcurrentDictionary<string, Game> dCoupon = new ConcurrentDictionary<string, Game>();
          public static List<Task> awaitedTasks = new List<Task>();
          public const string resourcesPath = @"C:\users\paokf\Documents\VS Studio\GoalsParser\Resources\";
          public string jsonFullPath;
          public string json1Path;
          public string json2Path;
          public static HashSet<Game> FinalSet = new HashSet<Game>();
          public static HashSet<Game> GamesData;
          public DateTime LastDate = new DateTime();
          #endregion
          private void InitializeFields()
          {
               GamesData = new HashSet<Game>();
               jsonFullPath = resourcesPath + @"\jsonOutFull.json";
               json1Path = resourcesPath + @"\jOut1.json";
               json2Path = resourcesPath + @"\jOut2.json";
          }
          public MainForm()
          {
               InitializeFields();
               InitializeComponent();
               ResetButtons(true, false, false, false);

               // LOAD
          }

          /// <summary>
          /// Sets the 'Enabled' property of Load, Update, Update1 and Update2 buttons
          /// </summary>
          private void ResetButtons(bool load, bool u, bool u1, bool u2)
          {
               if (buttonLoadData.InvokeRequired)
                    buttonLoadData.BeginInvoke(new Action(() => { buttonLoadData.Enabled = load; }));
               else
                    this.buttonLoadData.Enabled = load;

               if (buttonUpdateMain.InvokeRequired)
                    buttonUpdateMain.BeginInvoke(new Action(() => { buttonUpdateMain.Enabled = u; }));
               else
                    this.buttonUpdateMain.Enabled = u;

               if (buttonUpdate1.InvokeRequired)
                    buttonUpdate1.BeginInvoke(new Action(() => { buttonUpdate1.Enabled = u1; }));
               else
                    this.buttonUpdate1.Enabled = u1;

               if (buttonUpdate2.InvokeRequired)
                    buttonUpdate2.BeginInvoke(new Action(() => { buttonUpdate2.Enabled = u2; }));
               else
                    this.buttonUpdate2.Enabled = u2;
          }
          private void buttonLoadData_Click(object sender, EventArgs e)
          {
               buttonLoadData.Enabled = false;
               Task t = Task.Run(() =>
               {
                    foreach (string line in File.ReadAllLines(resourcesPath + "jsonOutFull.json"))
                    {
                         GamesData.Add(JsonConvert.DeserializeObject<Game>(line));
                    }
               }).ContinueWith(result =>
               {
                    int timeSpan = 100;
                    foreach (Game g in GamesData)
                    {
                         int dateDif = (int)(DateTime.Today - DateTime.Parse(g.gameDay)).TotalDays;
                         if (dateDif < timeSpan)
                         {
                              timeSpan = dateDif;
                              LastDate = DateTime.Parse(g.gameDay);
                         }
                    }

                    if (DateTime.Compare(LastDate, DateTime.Today.AddDays(-1)) == 0)
                    {
                         MessageBox.Show($"Games are up to date");
                         ResetButtons(true, false, false, false);
                    }
                    else
                    {
                         MessageBox.Show($"Last day was {LastDate.ToString("dd-MM-yyyy")}");
                         ResetButtons(false, true, false, false);
                    }

               });
          }
          /// <summary>
          /// Updates GamesData with
          /// </summary>
          /// <param name="sender"></param>
          /// <param name="e"></param>
          private void buttonUpdateMain_Click(object sender, EventArgs e)
          {
               buttonUpdateMain.Enabled = false;
               Task.Run(() => UpdateData(LastDate.ToString("yyyy-MM-dd"), DateTime.Today.ToString("yyyy-MM-dd")));
          }
          private async Task UpdateData(string startingDate, string endDate)
          {
               DateTime d1 = DateTime.Parse(startingDate);
               DateTime d2 = DateTime.Parse(endDate);

               int daysToParse = (int)(d2 - d1).TotalDays;

               for (int i = 0; i < daysToParse; i++)
               {
                    var d = d1.AddDays(i).ToString("yyyy-MM-dd");
                    var t1 = Task.Run(() => ScrapeTzirosAsync(d));
                    var t2 = Task.Run(() => ScrapeCouponAsync(d));

                    awaitedTasks.AddRange(new List<Task>() { t1, t2 });
               }

               await Task.Run(() => Task.WhenAll(awaitedTasks.ToArray()));

               foreach(string key in dTziros.Keys)
               {
                    if (dCoupon.ContainsKey(key))
                    {
                         FinalSet.Add(MergeGames(dCoupon[key], dTziros[key]));
                    }
               }
               MessageBox.Show($"There are {FinalSet.Count} new games to be added");

               WriteData(FinalSet.AsEnumerable(), jsonFullPath, wMode.Append);
          }
          private async Task ScrapeTzirosAsync(string date)
          {
               Game game = new Game();
               HtmlWeb web = new HtmlWeb();
               HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

               var url = $"https://www.goals.gr/tziroi/{date}/tziros/";
               doc = await web.LoadFromWebAsync(url);

               var rows = from table in doc.DocumentNode.SelectNodes("//table").Cast<HtmlNode>()
                          from row in table.SelectNodes("tr").Cast<HtmlNode>()
                          where row.Attributes.Contains("class") && row.Attributes["class"].Value != "betfair-spacer"
                          select row;
               
               foreach(HtmlNode row in rows)
               {
                    string rowID = row.Attributes["id"].Value.Substring(0, 3);
                    switch (rowID)
                    {
                         case "bf1":
                              // Initialize new Game object and populate its HomeTeam, and TotalTziros and gameID
                              game = new Game();
                              game.gameID = row.Attributes["id"].Value.Substring(4, row.Attributes["id"].Value.Length - 4);
                              game.teamHome = row.SelectSingleNode(".//td[@class = 'betfair-team-top']").InnerText;
                              game.totalTziros = NormalizeTziros(row.SelectSingleNode(".//td[@class = 'betfair-total bf-mom']").InnerText);
                              break;
                         case "bf2":
                              // Continue populating the Game object with Odds and Pcts
                              game.teamAway = row.SelectSingleNode(".//td[@class = 'betfair-team-bot']").InnerText;

                              var o1 = row.SelectSingleNode(".//td[@class = 'betfair-odd bf-1']").InnerText;
                              var oX = row.SelectSingleNode(".//td[@class = 'betfair-odd bf-X']").InnerText;
                              var o2 = row.SelectSingleNode(".//td[@class = 'betfair-odd bf-2']").InnerText;

                              o1 = o1.Contains(",") ? o1.Replace(",", ".") : "";
                              oX = oX.Contains(",") ? oX.Replace(",", ".") : "";
                              o2 = o2.Contains(",") ? o2.Replace(",", ".") : "";

                              var p1 = row.SelectSingleNode(".//td[@class = 'betfair-pct bf-1pct']").InnerText.Substring(0, row.SelectSingleNode(".//td[@class = 'betfair-pct bf-1pct']").InnerText.Length - 1);
                              var pX = row.SelectSingleNode(".//td[@class = 'betfair-pct bf-Xpct']").InnerText.Substring(0, row.SelectSingleNode(".//td[@class = 'betfair-pct bf-Xpct']").InnerText.Length - 1);
                              var p2 = row.SelectSingleNode(".//td[@class = 'betfair-pct bf-2pct']").InnerText.Substring(0, row.SelectSingleNode(".//td[@class = 'betfair-pct bf-2pct']").InnerText.Length - 1);

                              p1 = p1.Contains(",") ? p1.Replace(",", ".") : p1;
                              pX = pX.Contains(",") ? pX.Replace(",", ".") : pX;
                              p2 = p2.Contains(",") ? p2.Replace(",", ".") : p2;

                              game.pct1 = p1.Length > 0 ? float.Parse(p1) : 0;
                              game.pctX = pX.Length > 0 ? float.Parse(pX) : 0;
                              game.pct2 = p2.Length > 0 ? float.Parse(p2) : 0;

                              if (game.pct1 > 0 && game.pctX > 0 && game.pct2 > 0)
                              {
                                   dTziros.TryAdd(game.gameID, game);
                              }
                              break;
                    }

               }
          }
          private async Task ScrapeCouponAsync(string date)
          {
               HtmlWeb web = new HtmlWeb();
               HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

               var url = $"https://www.goals.gr/coupon/{date}";
               doc = await web.LoadFromWebAsync(url);

               var rows = from table in doc.DocumentNode.SelectNodes("//table").Cast<HtmlNode>()
                          from row in table.SelectNodes("tr").Cast<HtmlNode>()
                          where row.Attributes.Contains("class")
                          && row.Attributes["class"].Value != "ad-row"
                          select row;

               foreach (var row in rows)
               {
                    // ΒΡΙΣΚΕΙ 4 ΤΙΜΕΣ. Η 4Η ΔΕΝ ΞΕΡΩ ΤΙ ΕΙΝΑΙ. ΟΙ ΠΡΩΤΕΣ 3 ΕΙΝΑΙ ΑΠΟΔΟΣΕΙΣ
                    var live_odds = row.ChildNodes.Where(g => g.Attributes["class"].Value == "live-odds link").ToList();
                    var id = row.Attributes["id"].Value;

                    var _tHome = row.SelectSingleNode(".//td[@class = 'live-home']").InnerText;
                    var _tAway = row.SelectSingleNode(".//td[@class = 'live-away']").InnerText;
                    var _score = row.SelectSingleNode(".//td[@class = 'live-score']").InnerText;
                    var _comp = row.SelectSingleNode(".//td[@class = 'live-flag']").FirstChild.Attributes["title"].Value;

                    var o1 = live_odds[0].InnerText.Length > 1 ? live_odds[0].InnerText.Replace(",", ".") : "0";
                    var oX = live_odds[1].InnerText.Length > 1 ? live_odds[1].InnerText.Replace(",", ".") : "0";
                    var o2 = live_odds[2].InnerText.Length > 1 ? live_odds[2].InnerText.Replace(",", ".") : "0";
                    var _result = _score.Length == 3 ? int.Parse(_score.Substring(0, 1)) > int.Parse(_score.Substring(_score.Length - 1, 1)) ? Game.Results.ASSOS : int.Parse(_score.Substring(0, 1)) == int.Parse(_score.Substring(_score.Length - 1, 1)) ? Game.Results.X : Game.Results.DIPLO : Game.Results.NaN;

                    if (o1.Length > 1 && oX.Length > 1 && o2.Length > 1 && _score.Length > 1)
                    {
                         Game game = new Game()
                         {
                              gameID = id.Substring(2, id.Length - 2),
                              competition = _comp,
                              teamHome = _tHome,
                              teamAway = _tAway,
                              gameDay = date,
                              score = _score,
                              result = _result,
                              odds1 = float.Parse(o1),
                              oddsX = float.Parse(oX),
                              odds2 = float.Parse(o2)
                         };
                         dCoupon.TryAdd(game.gameID, game);
                    }
               }
               System.Console.WriteLine($"Finished Coupon {date}");

          }
          public double NormalizeTziros(string g)
          {
               return double.Parse(g.Substring(6, g.Length - 6).Split(",".ToCharArray(), 2)[0].Replace(".", ""));
          }
          public Game MergeGames(Game g1, Game g2)
          {
               // ΤΟ g1 EINAI ΑΠΟ ΤΟ ΚΟΥΠΟΝΙ, ΤΟ G2 ΕΙΝΑΙ ΑΠΟ ΤΟΝ ΤΖΙΡΟ
               Game g3 = new Game()
               {
                    gameID = g1.gameID,
                    teamAway = g1.teamAway,
                    teamHome = g1.teamHome,
                    gameDay = DateTime.Parse(g1.gameDay).ToString("dd-MM-yy"),
                    competition = g1.competition,

                    // ΔΕΔΟΜΕΝΑ ΑΠΟ ΤΟ ΚΟΥΠΟΝΙ
                    odds1 = g1.odds1,
                    oddsX = g1.oddsX,
                    odds2 = g1.odds2,
                    score = g1.score,
                    result = g1.result,

                    // ΔΕΔΟΜΕΝΑ ΑΠΟ ΤΟΝ ΤΖΙΡΟ
                    totalTziros = g2.totalTziros,
                    pct1 = g2.pct1,
                    pctX = g2.pctX,
                    pct2 = g2.pct2,
               };
               return g3;
          }
          /// <summary>
          /// Creates or over-writes .json file using provided <paramref name="data"/> to the
          /// specified <paramref name="outputFile"/> path.</summary>
          public static void WriteData(IEnumerable<Game> data, string outputFile, wMode mode)
          {
               switch (mode)
               {
                    case wMode.Write:
                         using (TextWriter writer = File.CreateText(outputFile))
                         {
                              foreach (Game g in data)
                              {
                                   writer.WriteLine(JsonConvert.SerializeObject(g));
                              }
                         }
                         break;
                    case wMode.Append:
                         using (TextWriter writer = File.AppendText(outputFile))
                         {
                              foreach (Game g in data)
                              {
                                   writer.WriteLine(JsonConvert.SerializeObject(g));
                              }
                         }
                         break;
               }
          }
     }
}
