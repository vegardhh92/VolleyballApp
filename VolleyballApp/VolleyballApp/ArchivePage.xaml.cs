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
			InitializeComponent ();

            database = new db.Database();

            // Create observable collection and populate from DB
            gamesObs = new ObservableCollection<db.Game>();
            database.GetGames().ToList()
                .ForEach(gamesObs.Add);

            // Add observable collection as ItemSource for ListView
            gamesListView.ItemsSource = gamesObs;

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