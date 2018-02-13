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

      
            string home = homeTeamEntry.Text;
            string away = awayTeamEntry.Text;
            DateTime gameDate2 = gameDate.Date;


            DisplayAlert("Success", home + " vs. " + away + " at " + gameDate2.ToString(), "Great");
        }
    }
}