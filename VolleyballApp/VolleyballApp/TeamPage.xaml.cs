using System;
using Xamarin.Forms;

namespace VolleyballApp
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeamPage : ContentPage
    {
        public PlayerDatabase playerDatabase;
        public Player player;

        public TeamPage()
        {
            InitializeComponent();
        }

        public void Save_Button_Clicked(object o, EventArgs e)
        {
            string numberFromInput = numberEntry.Text;

            player = new Player();
            playerDatabase = new PlayerDatabase();
            player.Number = Convert.ToInt32(numberFromInput);
            player.Name = nameEntry.Text;
            player.Position = positionEntry.Items[positionEntry.SelectedIndex];
            playerDatabase.AddPlayer(player);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

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
