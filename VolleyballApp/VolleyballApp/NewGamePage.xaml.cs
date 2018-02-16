using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VolleyballApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewGamePage : ContentPage
	{
        public db.Database database;
        public ObservableCollection<db.Player> availablePlayers;
        public ObservableCollection<db.Player> currentPlayersOnTeam;

        public NewGamePage ()
		{
			InitializeComponent ();

            database = new db.Database();
            availablePlayers = new ObservableCollection<db.Player>();
            currentPlayersOnTeam = new ObservableCollection<db.Player>();

            // Add all players from db to available players
            database.GetPlayers().ToList()
                .ForEach(availablePlayers.Add);

            // Set ListView sources
            availablePlayersListView.ItemsSource = availablePlayers;
            currentPlayersOnTeamListView.ItemsSource = currentPlayersOnTeam;
		}

        public void SubmitNewGame(Object o, EventArgs e)
        {
            db.Game game = new db.Game()
            {
                HomeTeam = homeTeamEntry.Text,
                AwayTeam = awayTeamEntry.Text,
                Date = gameDate.Date,
                Players = new List<db.Player>(currentPlayersOnTeam)
            };
           
            database.AddGame(game);

            int gameId = game.Id;

           // DisplayAlert("Info!", database.GetGameFromId(gameId).Description,  "Ok");

            ClearFields();
            //if(database.GetPlayers().Count() > 0) { 
            if (game.Players.Count > 0) { 
                Navigation.PushAsync(new GameStatisticsPage(gameId));
            }
            else
            {
                DisplayAlert("NO PLAYERS", "Cannot continue, you have no players", "OK");
                Navigation.PushAsync(new MyPlayersPage());
            }

        }

        public void AddPlayerToCurrent(object sender, EventArgs e)
        {
            var item = (Button)sender;
            db.Player player = (db.Player)item.CommandParameter;

            availablePlayers.Remove(player);
            currentPlayersOnTeam.Add(player);
        }

        public void RemovePlayerFromCurrent(object sender, EventArgs e)
        {
            var item = (Button)sender;
            db.Player player = (db.Player)item.CommandParameter;

            availablePlayers.Add(player);
            currentPlayersOnTeam.Remove(player);
        }

        public void ClearFields()
        {
            homeTeamEntry.Text = "";
            awayTeamEntry.Text = "";
            gameDate.Date = DateTime.Now;

            availablePlayers.Clear();
            database.GetPlayers().ToList()
                .ForEach(availablePlayers.Add);
            currentPlayersOnTeam.Clear();
        }
    }
}