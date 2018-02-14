using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace VolleyballApp
{
    public class Team
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        //public List<Game> Games{ get; private set; }

        public string Name { get; set; }

        /*
        public void addPlayer(Player player)
        {
            Players.Add(player);
        }

        public void addGame(Game game)
        {
            Games.Add(game);
        }
        */

        public Team()
        {
            //Players = new List<Player>();
            //Games = new List<Game>();
        }
    }
}
