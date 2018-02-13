using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace VolleyballApp
{
    public class Game
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public List<string> Teams { get; set; }
        public string GameScore { get; set; }
        public List<string> SetScores { get; set; }

        public Game()
        {
        }
    }
}
