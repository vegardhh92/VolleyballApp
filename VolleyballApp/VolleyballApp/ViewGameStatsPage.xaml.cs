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
	public partial class ViewGameStatsPage : ContentPage
	{
        private db.Database database;
        private db.Game game;

		public ViewGameStatsPage (int gameId)
		{
			InitializeComponent ();

            // Get game from sent Id
            database = new db.Database();
            game = database.GetGameFromId(gameId);
            List<db.Player> players = game.Players;
            System.Diagnostics.Debug.WriteLine(players.Count);

            // Set elements
            title.Text = game.Description;
            gameScore.Text = "Game score: " + game.GameScore;
		}
	}
}