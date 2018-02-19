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


            if(Navigation.NavigationStack.Count > 1)
            {
                Navigation.PopToRootAsync();
                System.Diagnostics.Debug.WriteLine("Nav stack > 1");
            }

         
        }

        private void New_Game_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewGamePage());
        }

        private void Archive_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ArchivePage());
        }

        private void Team_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MyPlayersPage());
        }

    }
}