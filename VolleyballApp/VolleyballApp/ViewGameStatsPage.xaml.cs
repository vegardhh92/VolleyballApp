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
	public partial class ViewGameStatsPage : ContentPage
	{
        private db.Database database;
        private db.Game game;
        private ObservableCollection<db.Player> playersObs;

		public ViewGameStatsPage (int gameId)
		{
			InitializeComponent ();

            // Get game from sent Id
            database = new db.Database();
            game = database.GetGameFromId(gameId);

            // Add players if they exist
            if (game.Players.Count > 0)
            {
                playersObs = new ObservableCollection<db.Player>();
                game.Players.ForEach(playersObs.Add);
                playersListView.ItemsSource = playersObs;
            }

            // Set elements
            title.Text = game.Description;
            gameScore.Text = "Game score: " + game.GameScore;
		}
	}
}