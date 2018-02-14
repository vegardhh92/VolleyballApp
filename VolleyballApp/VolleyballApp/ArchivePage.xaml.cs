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
			InitializeComponent ();

            database = new db.Database();
            var games = database.GetGames().ToList();

            gamesListView.ItemsSource = games;
		}
	}
}