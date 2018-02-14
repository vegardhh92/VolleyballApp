using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace VolleyballApp
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeamPage : ContentPage
    {
        public db.Database playerDatabase;
        public db.Player player;
        ObservableCollection<db.Player> playersObs = new ObservableCollection<db.Player>();

        public TeamPage()
        {
            InitializeComponent();

            //Fetching players from database
            playerDatabase = new db.Database();
            var players = playerDatabase.GetPlayers();
            players.ToList();

            for (int i = 0; i < players.Count(); i++)
            {
                db.Player p = new db.Player();
                p = players.ToList()[i];
                playersObs.Add(p);
            }
            teamMembersListView.ItemsSource = playersObs;
        }

        public void Save_Button_Clicked(object o, EventArgs e)
        {
            string numberFromInput = numberEntry.Text;

            player = new db.Player();

            playerDatabase = new db.Database();
            player.Number = Convert.ToInt32(numberFromInput);
            player.Name = nameEntry.Text;
            player.Position = positionEntry.Items[positionEntry.SelectedIndex];

            playerDatabase.AddPlayer(player);
            playersObs.Add(player);
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
       /*
            playerDatabase = new PlayerDatabase();
            player = new Player();
            var playersList = playerDatabase.GetPlayers();
            playersList.ToList();
            for (int i = 0; i < playersList.Count(); i++)
            {
                player = playersList.ToList()[i];
                playersObs.Add(player);
            }
            /*
                        playerDatabase = new PlayerDatabase();
                        var players = playerDatabase.GetPlayers();

                        teamMembersListView.ItemsSource = players;

                     /*  
                        using(SQLite.SQLiteConnection conn  = new SQLite.SQLiteConnection(App.DB_PATH))
                        {
                            conn.CreateTable<Player>();
                            var players = conn.Table<Player>().ToList();
                            teamMembersListView.ItemsSource = players;
                        }
                        */
        }
        /*
                public void Save_Button_Clicked(object sender, EventArgs e)
                {
                    string numberFromInput = numberEntry.Text;

                    Player player = new Player()
                    {

                        number = Convert.ToInt32(numberFromInput),
                        name = nameEntry.Text,
                        position = positionEntry.Items[positionEntry.SelectedIndex]
                    };
                    using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
                    {
                        conn.CreateTable<Player>();
                        var numberOfRows = conn.Insert(player);

                        if (numberOfRows > 0)
                            DisplayAlert("Success", "player successfully added", "OK");
                        else
                            DisplayAlert("Failure", "failed to insert player", "OK");
                    }
                   // DisplayAlert("Success", numberEntry.Text + player.name + player.position, "Great");

                }
                */
    }
}
