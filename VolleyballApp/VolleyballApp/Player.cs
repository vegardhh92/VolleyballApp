using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace VolleyballApp
{
    class Player
    {
        [PrimaryKey]
        public int number { get; set; }
        public string name { get; set; }
        public string position { get; set; }

    }
}
