using System;
using System.Collections.Generic;
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

        public NewGamePage ()
		{
			InitializeComponent ();

            database = new db.Database();
		}

        public void SubmitNewGame(Object o, EventArgs e)
        {
            db.Game game = new db.Game()
            {
                HomeTeam = homeTeamEntry.Text,
                AwayTeam = awayTeamEntry.Text,
                Date = gameDate.Date
            };
           
            database.AddGame(game);
            
            int gameId = game.Id;

           // DisplayAlert("Info!", database.GetGameFromId(gameId).Description,  "Ok");

            ClearFields();
            if(database.GetPlayers().Count() > 0) { 
                Navigation.PushAsync(new GameStatisticsPage(gameId));
            }
            else
            {
                DisplayAlert("NO PLAYERS", "Cannot continue, you have no players", "OK");
                Navigation.PushAsync(new MyPlayersPage());
            }

        }

        public void ClearFields()
        {
            homeTeamEntry.Text = "";
            awayTeamEntry.Text = "";
            gameDate.Date = DateTime.Now;
        }
    }
}