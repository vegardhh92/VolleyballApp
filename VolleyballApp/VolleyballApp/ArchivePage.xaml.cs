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
	public partial class ArchivePage : ContentPage
	{
        public db.Database database;
        public ObservableCollection<db.Game> gamesObs;

		public ArchivePage ()
		{
            System.Diagnostics.Debug.WriteLine("Hello archive");
			InitializeComponent ();
<<<<<<< HEAD
            System.Diagnostics.Debug.WriteLine("INIT");
            database = new db.Database();
            var games = database.GetGames().ToList();
            System.Diagnostics.Debug.WriteLine("Games to list");
            gamesListView.ItemsSource = games;
            System.Diagnostics.Debug.WriteLine("all done");
=======
            database = new db.Database();

            // Create observable collection and populate from DB
            gamesObs = new ObservableCollection<db.Game>();
            database.GetGames().ToList()
                .ForEach(gamesObs.Add);

            // Add observable collection as ItemSource for ListView
            gamesListView.ItemsSource = gamesObs;
>>>>>>> 3015576ca1b0f7803507fbf33eb21c50cbce149c
        }

        public void ViewGame(object sender, EventArgs e)
        {
            var item = (Xamarin.Forms.Button)sender;
            db.Game game = (db.Game)item.CommandParameter;

            Navigation.PushAsync(new ViewGameStatsPage(game.Id));
        }

        // TODO: add cancelable delete
        public void DeleteGame(object sender, EventArgs e)
        {
            // Get sent item from XAML
            var item = (Xamarin.Forms.Button)sender;
            db.Game game = (db.Game)item.CommandParameter;
            
            // Remove from database and collection
            database.DeleteGame(game);
            gamesObs.Remove(game);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}