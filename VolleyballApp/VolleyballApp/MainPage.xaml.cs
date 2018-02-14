using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VolleyballApp
{
  
    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            this.Title = "Volleyball statistics app";
		}

        private void New_Game_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewGamePage());
        }

        private void Archive_Clicked(object sender, EventArgs e)
        {
            //DisplayAlert("Success", "Clicked on Archive", "Great");
            Navigation.PushAsync(new ArchivePage());
        }

        private void Team_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TeamPage());
        }
        private void Statistics_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GameStatisticsPage());
        }

    }
}
