using SQLite;
using SQLiteNetExtensions.Attributes;
using SQLiteNetExtensions.Extensions;
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
        public string ServStats { get; set; }
        public string ReceptionStats { get; set; }
        public string AttackStats { get; set; }
        public string BlockStats { get; set; }
        public string DigStats { get; set; }

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
        public string Description { get { return HomeTeam + " vs. " + AwayTeam; } }

        public Game() { }

        public new string ToString => (
                HomeTeam + " vs. " +
                AwayTeam + " at " +
                Date
            );
    }

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
            return conn.GetAllWithChildren<Player>();
        }

        public IEnumerable<Game> GetGames()
        {
            return conn.GetAllWithChildren<Game>();
        }

        public Player GetPlayerFromId(int id)
        {
            return conn.GetWithChildren<Player>(id);
        }

        public Game GetGameFromId(int id)
        {
            return conn.GetWithChildren<Game>(id);
        }

        // INSERT
        public bool AddPlayer(Player player)
        {
            conn.InsertWithChildren(player);
            return true;
        }

        public bool AddGame(Game game)
        {
            conn.InsertWithChildren(game);
            return true;
        }

        // UPDATE
        public bool UpdatePlayer(Player player)
        {
            conn.UpdateWithChildren(player);
            return true;
        }

        public bool UpdateGame(Game game)
        {
            conn.UpdateWithChildren(game);
            return true;
        }

        // DELETE
        public bool DeletePlayer(Player player)
        {
            conn.Delete(player);
            return true;
        }

        public bool DeleteGame(Game game)
        {
            conn.Delete(game);
            return true;
        }
    }
}
