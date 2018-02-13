using System;
using System.Collections.Generic;
using System.Text;

namespace VolleyballApp
{
    class Game
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
