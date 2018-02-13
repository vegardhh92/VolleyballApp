﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace VolleyballApp
{
    class Team
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Player> Players { get; set; }

        public Team()
        {
        }
    }
}
