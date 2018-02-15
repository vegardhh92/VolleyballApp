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
        public EndGamePage (int gameId)
		{
			InitializeComponent ();
            int myGameId = gameId;
            database = new db.Database();
            System.Diagnostics.Debug.WriteLine("HELLO END GAME PAGE " + myGameId.ToString());
            //game = new db.Game();
            db.Game game = database.GetGameFromId(myGameId);
            System.Diagnostics.Debug.WriteLine("GET GAME?");
            teams.Text = game.Description;
            DateLabel.Text = game.Date.ToString();
		}
	}
}