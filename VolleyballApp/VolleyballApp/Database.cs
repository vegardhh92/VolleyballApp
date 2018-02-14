using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace db
{
    [Table("Players")]
    public class Player
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ManyToMany(typeof(PlayerGame))]
        public List<Game> Games { get; set; }

        public int Number { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }

        public Player() { }
    }

    [Table("Games")]
    public class Game
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        [ManyToMany(typeof(PlayerGame))]
        public List<Player> Players { get; set; }

        public DateTime Date { get; set; }
        public string GameScore { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }

        public Game() { }

        public new string ToString => (
                HomeTeam + " vs. " +
                AwayTeam + " at " +
                Date
            );
    }

    /*
    public class SetScore
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Score { get; set; }
    }
    */

    public class PlayerGame
    {
        [ForeignKey(typeof(Player))]
        public int PlayerId { get; set; }

        [ForeignKey(typeof(Game))]
        public int GameId { get; set; }
    }

    public class Database
    {
        private SQLiteConnection conn;

        // CREATE
        public Database()
        {
            conn = DependencyService.Get<VolleyballApp.ISQLite>().GetConnection();

            conn.CreateTable<Player>();
            conn.CreateTable<Game>();
            conn.CreateTable<PlayerGame>();
        }

        // READ
        public IEnumerable<Player> GetPlayers()
        {
            return (from player in conn.Table<Player>() select player).ToList();
        }

        public IEnumerable<Game> GetGames()
        {
            return (from game in conn.Table<Game>() select game).ToList();
        }

        public Player GetFirstPlayer()
        {
            return conn.Table<Player>().FirstOrDefault();
        }

        public Game GetFirstGame()
        {
            return conn.Table<Game>().FirstOrDefault();
        }

        public Player GetLastPlayer()
        {
            return conn.Table<Player>().LastOrDefault();
        }

        public Game GetLastGame()
        {
            return conn.Table<Game>().LastOrDefault();
        }

        // INSERT
        public bool AddPlayer(Player player)
        {
            conn.Insert(player);
            return true;
        }

        public bool AddGame(Game game)
        {
            conn.Insert(game);
            return true;
        }

        // UPDATE
        public bool UpdatePlayer(Player player)
        {
            conn.Update(player);
            return true;
        }

        public bool UpdateGame(Game game)
        {
            conn.Update(game);
            return true;
        }

        // DELETE
        
    }
}
