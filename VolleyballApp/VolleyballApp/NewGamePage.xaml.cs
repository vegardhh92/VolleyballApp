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
            database.AddGame(new db.Game()
            {
                HomeTeam = homeTeamEntry.Text,
                AwayTeam = awayTeamEntry.Text,
                Date = gameDate.Date
            });

            DisplayAlert("Info!", database.GetLastGame().ToString, "Ok");

            ClearFields();
        }

        public void ClearFields()
        {
            homeTeamEntry.Text = "";
            awayTeamEntry.Text = "";
            gameDate.Date = DateTime.Now;
        }
    }
}