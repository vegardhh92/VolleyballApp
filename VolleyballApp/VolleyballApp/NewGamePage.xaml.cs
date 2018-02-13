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
        public Team homeTeam;
        public Team awayTeam;
        public Game game;

        public NewGamePage ()
		{
			InitializeComponent ();
		}

        public void SubmitNewGame(Object o, EventArgs e)
        {
            homeTeam = new Team();
            awayTeam = new Team();
            game = new Game();

            homeTeam.Name = homeTeamEntry.Text;
            awayTeam.Name = awayTeamEntry.Text;

            game.Date = gameDate.Date;
            game.HomeTeam = homeTeam;
            game.AwayTeam = awayTeam;

            DisplayAlert("Success", game.HomeTeam.ToString() + " vs. " + game.AwayTeam.ToString() + " at " + game.Date.ToString(), "Great");
        }
    }
}