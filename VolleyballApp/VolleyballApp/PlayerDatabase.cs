using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace VolleyballApp
{
   public class PlayerDatabase
    {
        private SQLiteConnection conn;

        //CREATE  
        public PlayerDatabase()
        {
            conn = DependencyService.Get<ISQLite>().GetConnection();
            conn.CreateTable<Player>();
        }

        //READ  
        public IEnumerable<Player> GetPlayers()
        {
            var players = (from player in conn.Table<Player>() select player);
            return players.ToList();
        }
        //INSERT  
        public string AddPlayer(Player player)
        {
            conn.Insert(player);
            return "success";
        }
        //DELETE  
        public string DeletePlayer(string name)
        {
            conn.Delete<Player>(name);
            return "success";
        }
    }
}
