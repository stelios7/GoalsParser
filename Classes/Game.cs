using System;

namespace GoalsParser
{
     public class Game : IComparable, IEquatable<Game>
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
          public string gameID { get; set; }
          public string gameDay { get; set; }
          public string teamAway { get; set; }
          public string teamHome { get; set; }
          public string score { get; set; }
          public string competition { get; set; }
          public Results result { get; set; }
          public double totalTziros { get; set; }
          public float pct1 { get; set; }
          public float pctX { get; set; }
          public float pct2 { get; set; }
          public float oddsX { get; set; }
          public float odds2 { get; set; }
          public float odds1{ get; set; }

          public bool Over15
          {
               get
               {
                    return int.Parse(this.score.Split("-".ToCharArray(), 2)[0]) + int.Parse(this.score.Split("-".ToCharArray(), 2)[1]) > 1.5;
               }
          }
          public bool Over25
          {
               get
               {
                    return int.Parse(this.score.Split("-".ToCharArray(), 2)[0]) + int.Parse(this.score.Split("-".ToCharArray(), 2)[1]) > 2.5;
               }
          }
          public bool Over35
          {
               get
               {
                    return int.Parse(this.score.Split("-".ToCharArray(), 2)[0]) + int.Parse(this.score.Split("-".ToCharArray(), 2)[1]) > 3.5;
               }
          }
          public int CompareTo(object obj)
          {
               return gameDay.CompareTo(obj);
          }

          public bool Equals(Game other)
          {
               return this.competition.Equals(other.competition);
          }
          public bool pct1IsCloseTo(float target, float margin)
          {
               return Math.Abs(target - this.pct1) <= margin;
          }
          public bool pct2IsCloseTo(float target, float margin)
          {
               return Math.Abs(target - this.pct2) <= margin;
          }

          public bool pctXIsCloseTo(float target, float margin)
          {
               return Math.Abs(target - this.pctX) <= margin;
          }
     }
}
