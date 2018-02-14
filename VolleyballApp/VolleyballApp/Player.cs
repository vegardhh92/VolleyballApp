using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace VolleyballApp
{
    public class Player
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public int Number { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }

        public Player()
        {
        }
    }
   
}
