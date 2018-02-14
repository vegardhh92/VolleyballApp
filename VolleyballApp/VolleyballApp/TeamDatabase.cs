using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace VolleyballApp
{
    public class TeamDatabase
    {
        private SQLiteConnection conn;

        // CREATE
        public TeamDatabase()
        {
            conn = DependencyService.Get<ISQLite>().GetConnection();
            conn.CreateTable<Team>();
        }

        // READ
        public IEnumerable<Team> GetTeams()
        {
            var teams = (from team in conn.Table<Team>() select team);
            return teams.ToList();
        }

        public Team GetTeam(string teamName)
        {
            //var getteam = (from team in conn.Table<Team>() select team);
            //return (from team in conn.Table<Team>() where team.Name == teamName select team);
            return conn.Table<Team>()
                .Where(t => t.Name == teamName)
                .FirstOrDefault();
        }

        // INSERT
        public string AddTeam(Team team)
        {
            conn.Insert(team);
            return "success";
        }

        // DELETE
        public string DeleteTeam(string teamName)
        {
            conn.Delete<Team>(teamName);
            return "success";
        }
    }
}
