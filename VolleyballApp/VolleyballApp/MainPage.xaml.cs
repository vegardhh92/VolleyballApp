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
          //  System.Diagnostics.Debug.WriteLine("true? " + validator.servValidator(testString));
            testString = "0+12345";
            //  System.Diagnostics.Debug.WriteLine("False? " + validator.servValidator(testString));

           

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

/*
 * NUMBER VALIDATOR TESTS
            string numberTest1 = "1";
            System.Diagnostics.Debug.WriteLine("True 1? " + validator.pNumberValidator(numberTest1));

            string numberTest0 = "0";
            System.Diagnostics.Debug.WriteLine("false 0? " + validator.pNumberValidator(numberTest0));

            string numberTest20 = "20";
            System.Diagnostics.Debug.WriteLine("True 20 " + validator.pNumberValidator(numberTest20));

            string numberTest = null;
            System.Diagnostics.Debug.WriteLine("false null? " + validator.pNumberValidator(numberTest));

            string numberTestLetters = "1a2b";
            System.Diagnostics.Debug.WriteLine("faøse letters? " + validator.pNumberValidator(numberTestLetters));

            string numberTestabc = "abc";
            System.Diagnostics.Debug.WriteLine("false abc? " + validator.pNumberValidator(numberTestabc));


            NAME VALIDATOR
            string nameTestNull = null;
            System.Diagnostics.Debug.WriteLine("false null? " + validator.pNameValidator(nameTestNull));

            string nameTestOnlyLetters = "abcdef";
            System.Diagnostics.Debug.WriteLine("true abcdef? " + validator.pNameValidator(nameTestOnlyLetters));

            string nameTestBindestrek = "ole-anton";
            System.Diagnostics.Debug.WriteLine("true ole-anton? " + validator.pNameValidator(nameTestBindestrek));

             string nameTestNumb = "ole123";
            System.Diagnostics.Debug.WriteLine("false null? " + validator.pNameValidator(nameTestNumb));
 
     */
