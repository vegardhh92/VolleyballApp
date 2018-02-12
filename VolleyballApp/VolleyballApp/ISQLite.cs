using System;
using System.Collections.Generic;
using System.Text;

namespace VolleyballApp
{
    public interface ISQLite
    {
        SQLite.SQLiteConnection GetConnection();
    }
}
