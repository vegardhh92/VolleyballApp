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
	public partial class ArchivePage : ContentPage
	{
        public db.Database database;

		public ArchivePage ()
		{
            System.Diagnostics.Debug.WriteLine("Hello archive");
			InitializeComponent ();
            System.Diagnostics.Debug.WriteLine("INIT");
            database = new db.Database();
            var games = database.GetGames().ToList();
            System.Diagnostics.Debug.WriteLine("Games to list");
            gamesListView.ItemsSource = games;
            System.Diagnostics.Debug.WriteLine("all done");
        }

        public void ViewGame(object sender, EventArgs e)
        {
            var item = (Xamarin.Forms.Button)sender;
            DisplayAlert("Info", item.CommandParameter.ToString(), "OK");
            // Open ViewGameStats
        }

        public void DeleteGame(object sender, EventArgs e)
        {
            // Delete the game
            DisplayAlert("Info", "Delete Game", "OK");
        }
    }
}