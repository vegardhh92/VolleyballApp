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
        public int GameId;
        public GameStatisticsPage (int gameId)
		{

             GameId = gameId;
			InitializeComponent ();
            //Fetching players from database
            playerDatabase = db.Database.Instance;
            var players = playerDatabase.GetPlayers();
            players.ToList();
            myEntryList = new List<Entry>();
            //Setting backgroundcolor for mocking borders in our table
            BackgroundColor = Color.DodgerBlue;
            DisplayAlert("GAME ID", GameId.ToString(), "OK");
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
            System.Diagnostics.Debug.WriteLine("FIRST IN ON_CLICK " + GameId.ToString());
            getDataFromFields();
            System.Diagnostics.Debug.WriteLine("AFTER GET DATA");
            Navigation.PushAsync(new EndGamePage(GameId));
        }
        private void getDataFromFields()
        {
            //connect to DB
            playerDatabase = db.Database.Instance;
            var players = playerDatabase.GetPlayers();
            //Create list of players in DB
            List<db.Player> pList =  players.ToList();
            
            string inputText = "";
            //loop through every player in database
            foreach (db.Player p in pList)
            {
                string pname = p.Name;
                //go through every entry in the grid
                foreach (Entry statsEntry in myEntryList)
                {
                    //field for serv
                    if (statsEntry.ClassId == pname + 1)
                    {
                        inputText = statsEntry.Text;
                        System.Diagnostics.Debug.WriteLine("in Player " + p.Name + ", Entry = SERV, input text = " + inputText);
                        p.ServStats = inputText;
                        playerDatabase.UpdatePlayer(p);

                    }
                    //field for reception
                    else if (statsEntry.ClassId == pname + 2)
                    {
                        inputText = statsEntry.Text;
                        System.Diagnostics.Debug.WriteLine("in Player " + p.Name + ", Entry = RECEPTION, input text = " + inputText);
                        p.ReceptionStats = inputText;
                        playerDatabase.UpdatePlayer(p);
                    }
                    //field for attack
                    else if (statsEntry.ClassId == pname + 3)
                    {
                        inputText = statsEntry.Text;
                        System.Diagnostics.Debug.WriteLine("in Player " + p.Name + ", Entry = ATTACK, input text = " + inputText);
                        p.AttackStats = inputText;
                        playerDatabase.UpdatePlayer(p);
                    }
                    //field for block
                    else if (statsEntry.ClassId == pname + 4)
                    {
                        inputText = statsEntry.Text;
                        System.Diagnostics.Debug.WriteLine("in Player " + p.Name + ", BLOCK, input text = " + inputText);
                        p.BlockStats = inputText;
                        playerDatabase.UpdatePlayer(p);
                    }
                    //field for dig
                    else if (statsEntry.ClassId == pname + 5)
                    {
                        inputText = statsEntry.Text;
                        System.Diagnostics.Debug.WriteLine("in Player " + p.Name + ", Entry = DIG, input text = " + inputText);
                        p.DigStats = inputText;
                        playerDatabase.UpdatePlayer(p);
                    }
                }
            }
          }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}