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
            DisplayAlert("Success", "Clicked on New Game", "Great");
        }

        private void Archive_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Success", "Clicked on Archive", "Great");
        }

        private void Team_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TeamPage());
        }
	}
}
