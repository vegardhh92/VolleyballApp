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
            //this.Title = "Volleyball statistics app";

            if(Navigation.NavigationStack.Count > 1)
            {
                Navigation.PopToRootAsync();
                System.Diagnostics.Debug.WriteLine("Nav stack > 1");
            }

            //Test for GameCalc
            string testString = "++++0-00-+-000-+00++0--000+++";
            Utils.GameCalc gc = new Utils.GameCalc();
           System.Diagnostics.Debug.WriteLine("should be 50%: " +  gc.attackEfficiency(testString));
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
            Navigation.PushAsync(new MyPlayersPage());
        }

    }
}
