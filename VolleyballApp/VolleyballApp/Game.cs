using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace VolleyballApp
{
    public class Game
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        //[OneToMany()]
        //public List<string> Teams { get; private set; }

        public DateTime Date { get; set; }
        public string GameScore { get; set; }
        //public List<string> SetScores { get; private set; }

        /*
        public void AddTeam(string teamName)
        {
            Teams.Add(teamName);
        }

        public void AddSetScore(string setScore)
        {
            SetScores.Add(setScore);
        }
        */

        public Game()
        {
            //Teams = new List<string>();
            //SetScores = new List<string>();
        }
    }
}
