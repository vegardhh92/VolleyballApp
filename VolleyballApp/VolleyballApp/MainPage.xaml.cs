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
            string testString = "";
            Utils.Validators validator = new Utils.Validators();
            System.Diagnostics.Debug.WriteLine("true? " + validator.servValidator(testString));
            testString = "0+12345";
            System.Diagnostics.Debug.WriteLine("False? " + validator.servValidator(testString));


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
