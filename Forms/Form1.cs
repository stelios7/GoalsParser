using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;
using System.Globalization;
using System.Reflection;

namespace GoalsParser
{
     public partial class MainForm : Form
     {
          #region DECLARATIONS
          #region ENUM
          public enum wMode { Write, Append }
          #endregion

          #region Dictionaries/Lists for GAME objects
          /// <remarks>
          /// Concurrent Dictionary to hold games scraped from TZIROS page
          /// </remarks>
          public static ConcurrentDictionary<string, Game> dTziros = new ConcurrentDictionary<string, Game>();
          /// <remarks>
          /// Concurrent Dictionary to hold games scraped from COUPON page
          /// </remarks>
          public static ConcurrentDictionary<string, Game> dCoupon = new ConcurrentDictionary<string, Game>();
          public static HashSet<Game> FinalSet = new HashSet<Game>();
          public static HashSet<Game> GamesData;
          #endregion

          public static List<Task> awaitedTasks = new List<Task>();
          public string filePathJsonDB;
          public string filePathOut1;
          public string filePathOut2;
          public DateTime LastDate = new DateTime();
          /// <remarks>
          /// This list holds all the available competions.
          /// </remarks>
          public List<string> Competitions = new List<string>();
          /// <remarks>
          /// This list is responsible for the main control functionality. Enabling/Disabling
          /// </remarks>
          public List<Control> mainControls;
          #endregion

          #region MOUSE DRAG FORM IMPLEMENTATION
          private bool mouseDown;
          private Point lastLocation;
          private void CustomMouseDown(object sender, MouseEventArgs e)
          {
               if (e.Button == MouseButtons.Left)
               {
                    mouseDown = true;
                    lastLocation = e.Location;
               }
               else
               {
                    ContextMenu cm = new ContextMenu();
                    cm.MenuItems.Add("CLOSE");
                    cm.MenuItems[0].Click += new System.EventHandler(CloseForm);
                    this.ContextMenu = cm;
               }
          }
          private void CloseForm(object sender, EventArgs e)
          {
               var answer = MessageBox.Show("KLEISIMO?", "Exit", MessageBoxButtons.OKCancel);
               if (answer == DialogResult.OK)
               {
                    this.Close();
               }
          }
          private void CustomMouseMove(object sender, MouseEventArgs e)
          {
               if(mouseDown)
               {
                    this.Location = new Point(
                         (this.Location.X - lastLocation.X) + e.X,
                         (this.Location.Y - lastLocation.Y) + e.Y
                         );
                    this.Update();
               }
          }
          #endregion
          private void InitializeFields()
          {
               #region Get jsonDB and create FilePaths
               StreamReader reader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("GoalsParser.Files.jsonDB.txt"));
               string text = reader.ReadToEnd();

               GamesData = new HashSet<Game>();
               var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GoalsParser\";

               Directory.CreateDirectory(path);
               if (!File.Exists(path + "jsonDB.txt"))
                    File.WriteAllText(path + "jsonDB.txt", text);

               filePathJsonDB = path + "jsonDB.txt";
               filePathOut1 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GoalsParser\out111.txt";
               filePathOut2 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\GoalsParser\out222.txt";
               #endregion

               // Create the mainControls list to allow enabling/disabling
               mainControls = new List<Control>()
               {
                    buttonUpdateMain,
                    buttonShowResults,
                    tableLayoutPanelSearchFilters,
                    tableLayoutPanel5,
                    tableLayoutPanel6
               };
          }
          public MainForm()
          {
               InitializeComponent();
               InitializeFields();
               SubscribeControls();
               DisableControls(mainControls);
          }
          /// <summary>
          /// Subscribe different Control Groups to specific events.
          /// <para>Drag window functionality</para>
          /// <para>Right click functionality</para>
          /// </summary>
          private void SubscribeControls()
          {
               List<Control> controls = new List<Control>()
               {
                    tableLayoutPanel1,
                    tableLayoutPanel2,
                    tableLayoutPanel5,
                    tableLayoutPanel6,
                    tableLayoutPanelSearchFilters
               };
               foreach (Control c in controls)
               {
                    c.MouseDown += new System.Windows.Forms.MouseEventHandler(CustomMouseDown);
                    c.MouseUp += new System.Windows.Forms.MouseEventHandler((s,e) => { mouseDown = false; });
                    c.MouseMove += new System.Windows.Forms.MouseEventHandler(CustomMouseMove);
               }

               controls = new List<Control>()
               {
                    textBoxOdds2,
                    textBoxOddsX,
                    textBoxOdds1,
                    textBoxTargetTziros,
                    textBoxTargetPct1,
                    textBoxTargetPctΧ,
                    textBoxTargetPct2,
               };
               foreach (Control c in controls)
               {
                    c.KeyDown += new System.Windows.Forms.KeyEventHandler((sender, e) =>
                    {
                         if(e.KeyCode == Keys.Enter)
                         {
                              PopulateDataGrid();
                         }
                    });
               }
          }

          private void EnableControls(List<Control> controls)
          {
               foreach (Control c in controls)
               {
                    if (c.InvokeRequired)
                         c.BeginInvoke(new Action(() => { c.Enabled = true; }));
                    else
                         c.Enabled = true;
               }
          }
          private void DisableControls(List<Control> controls)
          {
               foreach(Control c in controls)
               {
                    c.Enabled = false;
               }
          }
          /// <summary>
          /// Sets the 'Enabled' property of Load, Update, Update1 and Update2 buttons
          /// </summary>
          private void buttonLoadData_Click(object sender, EventArgs e)
          {
               buttonLoadData.Enabled = false;
               string[] lines = File.ReadAllLines(filePathJsonDB);
               progressBar1.Maximum = lines.Length;
               int k = 0;
               int step = 50;
               Task t = Task.Run(() =>
               {
                    foreach (string line in lines)
                    {
                         k++;
                         GamesData.Add(JsonConvert.DeserializeObject<Game>(line));

                         if (k % step == 0) progressBar1.Invoke(new Action(() => { progressBar1.Value += step; }));

                    }
               }).ContinueWith(result =>
               {
                    int timeSpan = 100;
                    foreach (Game g in GamesData)
                    {
                         int dateDif = (int)(DateTime.Today - DateTime.ParseExact(g.gameDay, "dd-MM-yy", CultureInfo.InvariantCulture)).TotalDays;
                         if (dateDif < timeSpan)
                         {
                              timeSpan = dateDif;
                              LastDate = DateTime.ParseExact(g.gameDay, "dd-MM-yy", CultureInfo.InvariantCulture);
                         }
                    }

                    if (DateTime.Compare(LastDate, DateTime.Today.AddDays(-1)) == 0)
                    {
                         MessageBox.Show($"Games are up to date {k}");
                         if (progressBar1.InvokeRequired)
                              progressBar1.Invoke(new Action(() => { progressBar1.Value = 0; }));
                         else
                              progressBar1.Value = 0;

                         EnableControls(mainControls);
                         buttonUpdateMain.Invoke(new Action(() => { buttonUpdateMain.Enabled = false; }));
                    }
                    else
                    {
                         MessageBox.Show($"Last day was {LastDate.ToString("dd-MM-yyyy")} {k}");
                         if (progressBar1.InvokeRequired)
                              progressBar1.Invoke(new Action(() => { progressBar1.Value = 0; }));
                         else
                              progressBar1.Value = 0;

                         if (buttonUpdateMain.InvokeRequired)
                              buttonUpdateMain.Invoke(new Action(() => { buttonUpdateMain.Enabled = true; }));
                         else
                              buttonUpdateMain.Enabled = true;   
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
               // UPDATES the main jsonDB.txt database file **!!AND!!** both out111/out222.txt files
               //buttonUpdateMain.Enabled = false;
               if (DateTime.Compare(LastDate, DateTime.Today.AddDays(-1)) != 0)
               {
                    Task t = Task.Run(() => UpdateData(LastDate.ToString("yyyy-MM-dd"), DateTime.Today.ToString("yyyy-MM-dd")))
                         .ContinueWith(result =>
                         {
                              // Apply basic filters to the data and write the first file
                              var g1 = from v in GamesData
                                       where v.totalTziros > 10000
                                       && v.pct1 > v.pctX && v.pct1 > v.pct2
                                       select v;
                              g1 = g1.OrderBy(g => g.pct1).ThenByDescending(g => g.odds1).ThenByDescending(g => g.oddsX);

                              // Apply basic filters to the data and write the first file
                              var g2 = from v in GamesData
                                       where v.totalTziros > 10000
                                       && v.pct2 > v.pctX && v.pct2 > v.pct1
                                       select v;
                              g2 = g2.OrderBy(g => g.pct2).ThenByDescending(g => g.odds2).ThenByDescending(g => g.odds1);

                              WriteFormattedData(g1, filePathOut1, wMode.Write);
                              WriteFormattedData(g2, filePathOut2, wMode.Write);
                         });
               }
               else
               {
                    var g1 = from v in GamesData
                             where v.totalTziros > 10000
                             && v.pct1 > v.pctX && v.pct1 > v.pct2
                             select v;
                    g1 = g1.OrderBy(g => g.pct1).ThenByDescending(g => g.odds1).ThenByDescending(g => g.oddsX);

                    var g2 = from v in GamesData
                             where v.totalTziros > 10000
                             && v.pct2 > v.pctX && v.pct2 > v.pct1
                             select v;
                    g2 = g2.OrderBy(g => g.pct2).ThenByDescending(g => g.odds2).ThenByDescending(g => g.odds1);

                    WriteFormattedData(g1, filePathOut1, wMode.Write);
                    WriteFormattedData(g2, filePathOut2, wMode.Write);
               }
          }
          private async Task UpdateData(string startingDate, string endDate)
          {
               DateTime d1 = DateTime.Parse(startingDate);
               DateTime d2 = DateTime.Parse(endDate);

               int daysToParse = (int)(d2 - d1).TotalDays;

               for (int i = 1; i < daysToParse; i++)
               {
                    var d = d1.AddDays(i).ToString("yyyy-MM-dd");
                    var t1 = Task.Run(() => ScrapeTzirosAsync(d));
                    var t2 = Task.Run(() => ScrapeCouponAsync(d));

                    awaitedTasks.AddRange(new List<Task>() { t1, t2 });
               }

               await Task.Run(() => Task.WhenAll(awaitedTasks.ToArray()));

               foreach (string key in dTziros.Keys)
               {
                    if (dCoupon.ContainsKey(key))
                    {
                         FinalSet.Add(MergeGames(dCoupon[key], dTziros[key]));
                    }
               }
               var vSet = FinalSet
                    .Where(g => g.pct1 > 0)
                    .Where(g => g.pctX > 0)
                    .Where(g => g.pct2 > 0)
                    .Where(g => g.odds1 > 0)
                    .Where(g => g.oddsX > 0)
                    .Where(g => g.odds2 > 0)
                    .Where(g => g.totalTziros > 0);
               //MessageBox.Show($"There are {vSet.Count<Game>()} new games to be added");

               WriteData(vSet, filePathJsonDB, wMode.Append);
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

               foreach (HtmlNode row in rows)
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
          /// Creates or over-writes a file using provided <paramref name="_games"/> to the specified <paramref name="_outFile"/> path.
          /// </summary>
          public static void WriteData(IEnumerable<Game> _games, string _outFile, wMode _mode)
          {
               if(_mode == wMode.Write)
               {
                    using (TextWriter writer = File.CreateText(_outFile))
                    {
                         foreach(Game g in _games)
                              writer.WriteLine(JsonConvert.SerializeObject(g));
                    }
               }
               else if(_mode == wMode.Append)
               {
                    using (StreamWriter writer = File.AppendText(_outFile))
                    {
                         foreach (Game g in _games)
                              writer.WriteLine(JsonConvert.SerializeObject(g));
                    }
               }
          }
          public void WriteFormattedData(IEnumerable<Game> data, string outputFile, wMode mode)
          {
               int lCount = data.Count();
               progressBar1.Invoke(new Action(() => { progressBar1.Maximum = lCount; }));
               switch (mode)
               {
                    case wMode.Write:
                         using (StreamWriter writer = File.CreateText(outputFile))
                         {
                              int sCount = 0;
                              int vIndex = 0;
                              int k = 0;
                              int step = 20;
                              foreach (Game g in data)
                              {
                                   k++;
                                   sCount = int.Parse(g.pct1.ToString().Split(".".ToCharArray(), 2)[0]);
                                   if (sCount > vIndex) {
                                        vIndex = sCount;
                                        writer.WriteLine($"\n{vIndex}\n");
                                   }
                                   StringBuilder text = new StringBuilder();
                                   text.AppendFormat("{0,7}", $"{g.pct1.ToString("0.00")}% ");
                                   text.AppendFormat("{0,7}", $"{g.pctX.ToString("0.00")}% ");
                                   text.AppendFormat("{0,9}", $"{g.pct2.ToString("0.00")}% / ");

                                   text.Append(g.result == Game.Results.ASSOS ? "1 / " : g.result == Game.Results.DIPLO ? "2 / " : "X / ");
                                   text.Append($"{g.score} / ");

                                   text.AppendFormat("{0,6}", $"{g.odds1.ToString("0.00")} ");
                                   text.AppendFormat("{0,6}", $"{g.oddsX.ToString("0.00")} ");
                                   text.AppendFormat("{0,9}", $"{g.odds2.ToString("0.00")}  / ");

                                   var o15 = g.Over15 ? "O15 " : "-  ";
                                   var o25 = g.Over25 ? "O25 " : "-  ";
                                   var o35 = g.Over35 ? "O35 / " : "-  / ";
                                   text.AppendFormat("{0,4} {1,4} {2,6}", o15, o25, o35);

                                   text.AppendFormat("{0,11}", $"{g.totalTziros.ToString().Trim()}€ / ");
                                   text.Append($"{DateTime.ParseExact(g.gameDay, "dd-MM-yy", CultureInfo.InvariantCulture).ToString("dd-MM-yyyy")} / ");
                                   text.Append($"{g.competition} / ");
                                   text.Append($"{g.teamHome} - {g.teamAway}");
                                   writer.WriteLine(text.ToString());
                                   if (k % step == 0)
                                   {
                                        progressBar1.Invoke(new Action(() => { progressBar1.Value += step; }));
                                   }
                              }
                              progressBar1.Invoke(new Action(() => { progressBar1.Value = 0; }));
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
          private void CreateOut1File(string path, IEnumerable<Game> data)
          {
               using (TextWriter writer = File.CreateText(path))
               {
                    foreach (Game game in data)
                    {
                         writer.WriteLine(StringifyGame(game));
                    }
               }
          }
          private string StringifyGame(Game game)
          {
               StringBuilder builder = new StringBuilder();
               builder.Append($"{game.pct1} {game.pctX} {game.pct2} / {game.result} / {game.score}");
               return builder.ToString();
          }
          private void buttonOpenFile1_Click(object sender, EventArgs e)
          {
               var data = from t in GamesData
                          where t.totalTziros > 10000
                          && t.pct1 > t.pctX && t.pct1 > t.pct2
                          select t;
               data = data.OrderBy(t => t.pct1).ThenByDescending(t => t.pctX);
               CreateOut1File(filePathOut1, data);
          }
          private void buttonShowResults_Click(object sender, EventArgs e)
          {
               PopulateDataGrid();
          }
          private void PopulateDataGrid()
          {
               string[] cNames = new string[12] { "% ΑΣΣΟΣ", "% Χ", "% ΔΙΠΛΟ", "ΤΕΛΙΚΟ", "ΣΚΟΡ", "ΑΠΟΔΟΣΗ 1", "ΑΠΟΔΟΣΗ Χ", "ΑΠΟΔΟΣΗ 2", "ΤΖΙΡΟΣ", "ΟΒΕΡ 1,5", "ΟΒΕΡ 2,5", "ΟΒΕΡ 3,5" };
               DataTable dt = new DataTable();
               dt.BeginLoadData();
               for (int i = 0; i < cNames.Length; i++)
               {
                    dt.Columns.Add(cNames[i]);
                    dt.Columns[i].AllowDBNull = true;
               }

               object[] filters = GetFilters();
               int tgTziros = (int)filters[0];
               float tp1 = (float)filters[1];
               float tpX = (float)filters[2];
               float tp2 = (float)filters[3];
               string tgMode = (string)filters[4];
               float margin = 0.02f;
               float tgO1 = (float)filters[5];
               float tgOX = (float)filters[6];
               float tgO2 = (float)filters[7];

               var vGames = GamesData
                    .Where(g => tgTziros > 0 ? g.totalTziros >= tgTziros : g.totalTziros > 10000)
                    .ToHashSet();

               if (tgMode == "SHOW1" || tgMode.Length == 0)
               {
                    vGames = vGames
                         .Where(g => g.pct1 > g.pct2 && g.pct1 > g.pctX)
                         //.Where(g => g.pct1IsCloseTo(tp1, margin))
                         .ToHashSet();
               }
               else
               {
                    vGames = vGames
                         .Where(g => g.pct2 > g.pct1 && g.pct2 > g.pctX)
                         //.Where(g => g.pct2IsCloseTo(tp1, margin))
                         .ToHashSet();
               }

               if (tp1 > 0)
                    vGames = vGames.Where(g => g.pct1IsCloseTo(tp1, margin)).ToHashSet();

               if (tpX > 0)
                    vGames = vGames.Where(g => g.pctXIsCloseTo(tpX, margin)).ToHashSet();

               if (tp2 > 0)
                    vGames = vGames.Where(g => g.pct2IsCloseTo(tp2, margin)).ToHashSet();

               if (tgO1 > 0)
                    vGames = vGames.Where(g => g.odds1 == tgO1).ToHashSet();

               if (tgOX > 0)
                    vGames = vGames.Where(g => g.oddsX == tgOX).ToHashSet();

               if (tgO2 > 0)
                    vGames = vGames.Where(g => g.odds2 == tgO2).ToHashSet();

               vGames = vGames
                    .OrderBy(g => tgMode == "SHOW1" || tgMode.Length == 0 ? g.pct1 : g.pct2)
                    .ThenBy(g => g.odds1)
                    .ThenBy(g => g.oddsX)
                    .ThenBy(g => g.odds2)
                    .ThenByDescending(g => g.pctX)
                    .ThenByDescending(g => g.pct2)
                    .ToHashSet();

               foreach (var item in vGames)
               {
                    dt.Rows.Add(
                         item.pct1.ToString("0.00"),
                         item.pctX.ToString("0.00"),
                         item.pct2.ToString("0.00"),
                         item.result == Game.Results.ASSOS ? "1" : item.result == Game.Results.DIPLO ? "2" : "X",
                         item.score,
                         item.odds1.ToString("0.00"),
                         item.oddsX.ToString("0.00"),
                         item.odds2.ToString("0.00"),
                         item.totalTziros,
                         item.Over15 ? "+" : string.Empty,
                         item.Over25 ? "+" : string.Empty,
                         item.Over35 ? "+" : string.Empty
                         );
               }
               labelDataCount.Text = String.Concat(vGames.Count.ToString(), " αποτελέσματα");
               dataGridView1.DataSource = dt;
          }
          private object[] GetFilters()
          {
               string pm1 = "SHOW1";
               string pm2 = "SHOW2";

               var previewMode = checkBoxShow1.Checked ? pm1 : checkBoxShow2.Checked ? pm2 : pm1;
               int tzirosTarget = 0;
               try{
                    tzirosTarget = int.Parse(textBoxTargetTziros.Text);
               }
               catch (System.FormatException fe){
                    //MessageBox.Show(string.Concat("LATHOS TZIROS"));
               }

               float p1 = 0f;
               if (textBoxTargetPct1.Text.Length > 0)
               {
                    try
                    {
                         p1 = float.Parse(textBoxTargetPct1.Text);
                    }
                    catch (FormatException fe)
                    {
                         textBoxTargetPct1.Text = string.Empty;
                    }
               }

               float pX = 0f;
               if (textBoxTargetPctΧ.Text.Length > 0)
               {
                    try
                    {
                         pX = float.Parse(textBoxTargetPctΧ.Text);
                    }
                    catch (FormatException fe)
                    {
                         textBoxTargetPctΧ.Text = string.Empty;
                    }
               }

               float p2 = 0f;
               if (textBoxTargetPct2.Text.Length > 0)
               {
                    try
                    {
                         p2 = float.Parse(textBoxTargetPct2.Text);
                    }
                    catch (FormatException fe)
                    {
                         textBoxTargetPct2.Text = string.Empty;
                    }
               }

               float t1 = 0;
               if (textBoxOdds1.Text.Length > 0)
               {
                    try
                    {
                         t1 = float.Parse(textBoxOdds1.Text);
                    }
                    catch (FormatException fe)
                    {
                         textBoxOdds1.Text = "";
                    }
               }

               float t2 = 0;
               if (textBoxOddsX.Text.Length > 0)
               {
                    try
                    {
                         t2 = float.Parse(textBoxOddsX.Text);
                    }
                    catch (FormatException fe)
                    {
                         textBoxOddsX.Text = "";
                    }
               }

               float t3 = 0;
               if (textBoxOdds2.Text.Length > 0)
               {
                    try
                    {
                         t3 = float.Parse(textBoxOdds2.Text);
                    }
                    catch (FormatException fe)
                    {
                         textBoxOdds2.Text = "";
                    }
               }

               return new object[8] { tzirosTarget, p1, pX, p2, previewMode, t1, t2, t3 };
          }
          private void checkBox1_CheckedChanged(object sender, EventArgs e)
          {
               if(checkBoxShow2.Checked && checkBoxShow1.Checked)
               {
                    checkBoxShow2.Checked = false;
               }
          }
          private void checkBoxShow2_CheckedChanged(object sender, EventArgs e)
          {
               if (checkBoxShow2.Checked && checkBoxShow1.Checked)
               {
                    checkBoxShow1.Checked = false;
               }
          }
     }
}
