using System;

namespace GoalsParser
{
     public class Game : IComparable
     {
          public enum Results { ASSOS, X, DIPLO, NaN }
          public Game()
          {
               gameID = "";
               teamAway = "";
               teamHome = "";
               gameDay = "";
               score = "";
               competition = "";
               totalTziros = 0;
               pct1 = 0;
               pct2 = 0;
               pctX = 0;
               odds1 = 0;
               odds2 = 0;
               oddsX = 0;
               result = Results.NaN;
          }
          public string gameID, gameDay, teamAway, teamHome, score, competition;
          public Results result;
          public double totalTziros;
          public float pct1, pctX, pct2;
          public float oddsX, odds2, odds1;
          public bool Over15
          {
               get
               {
                    return int.Parse(this.score.Split("-".ToCharArray(), 2)[0]) + int.Parse(this.score.Split("-".ToCharArray(), 2)[0]) > 1.5;
               }
          }
          public bool Over25
          {
               get
               {
                    return int.Parse(this.score.Split("-".ToCharArray(), 2)[0]) + int.Parse(this.score.Split("-".ToCharArray(), 2)[0]) > 2.5;
               }
          }
          public bool Over35
          {
               get
               {
                    return int.Parse(this.score.Split("-".ToCharArray(), 2)[0]) + int.Parse(this.score.Split("-".ToCharArray(), 2)[0]) > 3.5;
               }
          }
          public int CompareTo(object obj)
          {
               return gameDay.CompareTo(obj);
          }
     }
}
