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
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }

        public Game()
        {
        }
    }
}
