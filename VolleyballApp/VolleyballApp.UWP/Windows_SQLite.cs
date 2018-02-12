using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VolleyballApp.UWP;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(Windows_SQLite))]  
namespace VolleyballApp.UWP
{
    class Windows_SQLite : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "Player.sqlite";
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }

    }
}
