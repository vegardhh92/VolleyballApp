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
	public partial class EndGamePage : ContentPage
	{
        public db.Database database;
        public db.Player player;
        // public db.Game game;
        public int myGameId;
        public EndGamePage (int gameId)
		{
			InitializeComponent ();
            myGameId = gameId;
            database = db.Database.Instance;
            //database = new db.Database();
            System.Diagnostics.Debug.WriteLine("HELLO END GAME PAGE " + myGameId.ToString());
            //game = new db.Game();
            db.Game game = database.GetGameFromId(myGameId);
            System.Diagnostics.Debug.WriteLine("GET GAME?");
            teams.Text = game.Description;
		}

        public void Save_Clicked()
        {

            int thisGameId = myGameId;
            System.Diagnostics.Debug.WriteLine("GET ID");
            string gameScore = gameScoreEntry.Text;
            System.Diagnostics.Debug.WriteLine("GET TEXT");
            db.Game g = database.GetGameFromId(thisGameId);
            System.Diagnostics.Debug.WriteLine("GET GAME WITH ID");
            g.GameScore = gameScore;
            System.Diagnostics.Debug.WriteLine("set game score");
            database.UpdateGame(g);
            System.Diagnostics.Debug.WriteLine("UPDATED GAME");
            System.Diagnostics.Debug.WriteLine(database.GetGameFromId(thisGameId).GameScore);

            Navigation.PopToRootAsync();
            showArchive();
            
        }
        async void showArchive()
        {
            
            var page = new MainPage();
            await Navigation.PushModalAsync(page);
        }
	}
}