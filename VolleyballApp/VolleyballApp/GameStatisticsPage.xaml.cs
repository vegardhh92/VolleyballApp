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
	public partial class GameStatisticsPage : ContentPage
	{
        public db.Database playerDatabase;
        public db.Player player;
        public Grid controlGrid;
        public List<Entry> myEntryList;

        public GameStatisticsPage ()
		{
			InitializeComponent ();
            //Fetching players from database
            playerDatabase = new db.Database();
            var players = playerDatabase.GetPlayers();
            players.ToList();
            myEntryList = new List<Entry>();
            //Setting backgroundcolor for mocking borders in our table
            BackgroundColor = Color.DodgerBlue;

            var controlGrid = new Grid { RowSpacing = 1, ColumnSpacing = 1 };

            var headerLabelStyle = new Style(typeof(Label))
            {
                Setters =
                {
                    new Setter{Property = Label.BackgroundColorProperty, Value = Color.White},
                    new Setter {Property = Label.TextColorProperty, Value = Color.Black},
                    new Setter{Property = Label.FontSizeProperty, Value = 20}
                }
            };
            //Style for labels
            var nameLabelStyle = new Style(typeof(Label))
            {
                Setters =
                {
                    new Setter{Property = Label.BackgroundColorProperty, Value = Color.White},
                    new Setter {Property = Label.TextColorProperty, Value = Color.Black},
                    new Setter{Property = Label.FontSizeProperty, Value = 20}
                }
            };
            //Style for entry
                var entryStyle = new Style(typeof(Entry))
                {
                    Setters =
                {
                    new Setter{Property = Entry.BackgroundColorProperty, Value = Color.White},
                    new Setter {Property = Entry.TextColorProperty, Value = Color.Black},
                    new Setter{Property = Entry.FontSizeProperty, Value = 20}
                }
                };

            //Setting up grid row and column definitions
           
            controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            controlGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            controlGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            controlGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            controlGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            controlGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            controlGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            controlGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            //Adding categories
            controlGrid.Children.Add(new Label { Text = "Name", Style = headerLabelStyle }, 0, 0);
            controlGrid.Children.Add(new Label { Text = "Serv", Style = headerLabelStyle }, 1, 0);
            controlGrid.Children.Add(new Label { Text = "Reception", Style = headerLabelStyle }, 2, 0);
            controlGrid.Children.Add(new Label { Text = "Attack", Style = headerLabelStyle }, 3, 0);
            controlGrid.Children.Add(new Label { Text = "Block", Style = headerLabelStyle }, 4, 0);
            controlGrid.Children.Add(new Label { Text = "Dig", Style = headerLabelStyle }, 5, 0);


            //Dynamically adding players from database and adding entry cells to the grid for each player
                int colNr = 0;
                int rowNr = 1;
           

                for (int i = 0; i < players.Count(); i++)
                {
                string pName = players.ToList()[i].Name;
                    controlGrid.Children.Add(new Label  { Text = pName, Style = nameLabelStyle }, colNr, rowNr);
                    colNr++;
                    while(colNr < 6)
                    {
                    string idString = pName + colNr.ToString();
                    myEntryList.Add(
                        new Entry{Style = entryStyle, ClassId = idString}
                    );
                     
                      //  controlGrid.Children.Add(new Entry  { Style = entryStyle, ClassId= idString}, colNr, rowNr);
                    System.Diagnostics.Debug.WriteLine(idString);
                    colNr++;
                }
                    colNr = 0;
                    rowNr++;
                }
            rowNr = 1;
            colNr = 1;
            int testnumber = 0;
            foreach (Entry e in myEntryList)
            {
              
               // e.Text = "Col, Row: " + colNr + "," + rowNr;
                //e.Text = players.ToList()[testnumber].Name;
                System.Diagnostics.Debug.WriteLine(e.ClassId.ToString() + " in for each");
                controlGrid.Children.Add(e, colNr, rowNr);
                
                colNr ++;

                if (colNr == 6)
                {
                    System.Diagnostics.Debug.WriteLine("colNr ble 6 + ");
                    colNr = 1;
                    testnumber++;
                    rowNr++;
                }
           
            }

            //Button for ending the game
            Button endGame = new Button();
            endGame.Text = "End Game";
            endGame.Clicked += EndGame_Clicked;
            controlGrid.Children.Add(endGame, 5, rowNr);
            string myString = players.ToList()[0].Name;

           Content = controlGrid;
            
        }

        private void EndGame_Clicked(object sender, EventArgs e)
        {
            playerDatabase = new db.Database();
            var players = playerDatabase.GetPlayers();
            players.ToList();
            string p1Serv;
            string p1Reception;
            string p1Attack;
            string p1Block;
            string p1Dig;

             
             Entry en = new Entry();
             foreach (Entry someEntry in myEntryList)
             {
                 if (someEntry.ClassId == "Olga1")
                 {
                    p1Serv = someEntry.Text;
                    db.Player p = players.ToList()[0];
                    p.ServStats = p1Serv;
                    playerDatabase.UpdatePlayer(p);
                     DisplayAlert("IS IT WORKING?", p1Serv, "YEAH 8-)");
                 }
                if (someEntry.ClassId == "Olga1")
                {
                  
                }


                 else
                 {
                     DisplayAlert("NOTHING WORKS", "NOPE", "SORRY");
                 }
             }

             /*

                         View view = controlGrid.Children.FirstOrDefault(v => Grid.GetRow(v) == 2 && Grid.GetColumn(v) == 2);
                         if (view is Entry entry)
                         {
                             myTEXT = entry.Text;
                         }
                         else
                             myTEXT = "FAIL";

                         DisplayAlert("TEST", myTEXT, "OK");
                         */
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}