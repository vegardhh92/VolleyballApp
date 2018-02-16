using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace VolleyballApp
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyPlayersPage : ContentPage
    {
        public db.Database playerDatabase;
        public db.Player player;
        ObservableCollection<db.Player> playersObs = new ObservableCollection<db.Player>();

        public MyPlayersPage()
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
            string name = nameEntry.Text;
            string position = positionEntry.Items[positionEntry.SelectedIndex];

            Utils.Validators validator = new Utils.Validators();
            if (validator.NewPlayerValidator(numberFromInput, name, position))
            {
                player = new db.Player();

                playerDatabase = new db.Database();
                player.Number = Convert.ToInt32(numberFromInput);
                player.Name = nameEntry.Text;
                player.Position = positionEntry.Items[positionEntry.SelectedIndex];

                playerDatabase.AddPlayer(player);
                playersObs.Add(player);
            }
            else
            {
                DisplayAlert("Invalid inputs", "some fields are invalid, try again", "OK");
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
