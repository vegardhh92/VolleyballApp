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
    public partial class GameStatsPageV2 : ContentPage
    {
        public db.Database playerDatabase;
        public db.Player player;
        public Grid controlGrid;
        public List<Editor> myEditorList;
        public int GameId;
        public GameStatsPageV2(int gameId)
        {

            GameId = gameId;
            InitializeComponent();
            //Fetching players from database
            playerDatabase = new db.Database();
            var players = playerDatabase.GetGameFromId(gameId).Players;
            // var players = playerDatabase.GetPlayers();
            players.ToList();
            myEditorList = new List<Editor>();
            //Setting backgroundcolor for mocking borders in our table
            BackgroundColor = Color.DodgerBlue;
            // DisplayAlert("GAME ID", GameId.ToString(), "OK");
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
            //Style for Editor
            var EditorStyle = new Style(typeof(Editor))
            {
                Setters =
                {
                    new Setter{Property = Editor.BackgroundColorProperty, Value = Color.White},
                    new Setter {Property = Editor.TextColorProperty, Value = Color.Black},
                    new Setter{Property = Editor.FontSizeProperty, Value = 20}
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


            //Dynamically adding players from database and adding Editor cells to the grid for each player
            int colNr = 0;
            int rowNr = 1;

            var buttonStyle = new Style(typeof(Button))
            {
                Setters =
                {
                    new Setter{Property = Button.BackgroundColorProperty, Value = Color.White},
                    new Setter {Property = Button.TextColorProperty, Value = Color.Blue},
                    new Setter {Property = Button.FontAttributesProperty, Value = FontAttributes.Bold},
                    new Setter {Property = Button.FontSizeProperty, Value = 15}
                }
            };

            for (int i = 0; i < players.Count(); i++)
            {
                string pName = players.ToList()[i].Name;
                string pPos = players.ToList()[i].Position;
                controlGrid.Children.Add(new Label { Text = pName, Style = nameLabelStyle }, colNr, rowNr);
                colNr++;
                while (colNr < 6)
                {
                    string idString = pName + colNr.ToString();
                    myEditorList.Add(
                        new Editor { Style = EditorStyle, ClassId = idString, WidthRequest = 100 }
                    );

                    //  controlGrid.Children.Add(new Editor  { Style = EditorStyle, ClassId= idString}, colNr, rowNr);
                    System.Diagnostics.Debug.WriteLine(idString);
                    colNr++;
                }
                colNr = 0;
                rowNr++;
            }
            rowNr = 1;
            colNr = 1;
            int testnumber = 0;
            foreach (Editor e in myEditorList)
            {

                e.VerticalOptions = LayoutOptions.FillAndExpand;

                System.Diagnostics.Debug.WriteLine(e.ClassId.ToString() + " in for each");
                switch (colNr)
                {
                    case 1:
                    case 3:  

                        Button pServButton = new Button()
                        {
                            Text = "+",
                            Style = buttonStyle
                        };
                        pServButton.Clicked += (Object o, EventArgs ev) => e.Text += "+";

                        Button nServButton = new Button()
                        {
                            Text = "0",
                            Style = buttonStyle
                        };
                        nServButton.Clicked += (Object o, EventArgs ev) => e.Text += "0";

                        Button mServButton = new Button()
                        {
                            Text = "-",
                            Style = buttonStyle
                        };
                        mServButton.Clicked += (Object o, EventArgs ev) => e.Text += "-";

                        controlGrid.Children.Add(new StackLayout()
                        {
                            Orientation = StackOrientation.Vertical,

                            Children =
                    {
                        e,
                        new StackLayout(){Orientation=StackOrientation.Horizontal,
                        Children =
                            {
                         pServButton, mServButton, nServButton
                            }
                    }
                    }
                        }, colNr, rowNr);
                        break;
                    case 2:

                        Button OneButton = new Button()
                        {
                            Text = "1",
                            Style = buttonStyle
                        };
                        OneButton.Clicked += (Object o, EventArgs ev) => e.Text += "1";

                        Button twoButton = new Button()
                        {
                            Text = "2",
                            Style = buttonStyle
                        };
                        twoButton.Clicked += (Object o, EventArgs ev) => e.Text += "2";
                        Button threeButton = new Button()
                        {
                            Text = "3",
                            Style = buttonStyle
                        };
                        threeButton.Clicked += (Object o, EventArgs ev) => e.Text += "3";

                        Button fourButton = new Button()
                        {
                            Text = "4",
                            Style = buttonStyle
                        };
                        fourButton.Clicked += (Object o, EventArgs ev) => e.Text += "4";
                        Button fiveButton = new Button()
                        {
                            Text = "5",
                            Style = buttonStyle
                        };
                        fiveButton.Clicked += (Object o, EventArgs ev) => e.Text += "5";

                        controlGrid.Children.Add(new StackLayout()
                        {
                            Orientation = StackOrientation.Vertical,

                            Children =
                    {
                        e,
                        new StackLayout(){Orientation=StackOrientation.Horizontal,
                        Children =
                            {
                         OneButton, twoButton, threeButton, fourButton, fiveButton
                            }
                    }
                    }
                        }, colNr, rowNr);
                        break;
                    case 4:
                        Button bpButton = new Button()
                        {
                            Text = "+",
                            Style = buttonStyle
                        };
                        bpButton.Clicked += (Object o, EventArgs ev) => e.Text += "+";

                        Button kbButton = new Button()
                        {
                            Text = "k",
                            Style = buttonStyle
                        };
                        kbButton.Clicked += (Object o, EventArgs ev) => e.Text += "k";


                        controlGrid.Children.Add(new StackLayout()
                        {
                            Orientation = StackOrientation.Vertical,

                            Children =
                    {
                        e,
                        new StackLayout(){Orientation=StackOrientation.Horizontal,
                        Children =
                            {
                         bpButton, kbButton
                            }
                    }
                    }
                        }, colNr, rowNr);
                        break;
                    case 5:
                        Button digButton = new Button()
                        {
                            Text = "!",
                            Style = buttonStyle
                        };
                        digButton.Clicked += (Object o, EventArgs ev) => e.Text += "!";


                        controlGrid.Children.Add(new StackLayout()
                        {
                            Orientation = StackOrientation.Vertical,

                            Children =
                    {
                        e,
                        new StackLayout(){Orientation=StackOrientation.Horizontal,
                        Children =
                            {
                         digButton
                            }
                    }
                    }
                        }, colNr, rowNr);
                        break;

                    default:
                        break;
                }
            /*    controlGrid.Children.Add(new StackLayout()
                {
                    Orientation = StackOrientation.Vertical,

                    Children =
                    {
                        e,
                        new StackLayout(){Orientation=StackOrientation.Horizontal,
                        Children =
                            {
                         pServButton, mServButton
                            }
                    }
                    }
                }, colNr, rowNr);
*/
                // controlGrid.Children.Add(e, colNr, rowNr);

                colNr++;

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
            endGame.Style = buttonStyle;
            endGame.Clicked += EndGame_Clicked;
            controlGrid.Children.Add(endGame, 5, rowNr);
            string myString = players.ToList()[0].Name;

            Content = controlGrid;

        }

        private void PButton_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void EndGame_Clicked(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("FIRST IN ON_CLICK " + GameId.ToString());
            if (getDataFromFields())
            {
                System.Diagnostics.Debug.WriteLine("getdata = true");
                Navigation.PushAsync(new EndGamePage(GameId));
            }
            System.Diagnostics.Debug.WriteLine("AFTER GET DATA");

        }
        private bool getDataFromFields()
        {
            //connect to DB
            playerDatabase = new db.Database();
            var players = playerDatabase.GetPlayers();
            //Create list of players in DB
            List<db.Player> pList = players.ToList();
            Utils.Validators validators = new Utils.Validators();
            string inputText = "";
            //loop through every player in database
            Boolean allOk = true;
            foreach (db.Player p in pList)
            {

                string pname = p.Name;
                //go through every Editor in the grid
                foreach (Editor statsEditor in myEditorList)
                {
                    //field for serv
                    if (statsEditor.ClassId == pname + 1)
                    {
                        if (statsEditor.Text == null)
                        {
                            inputText = "";
                        }
                        else
                        {
                            inputText = statsEditor.Text;
                        }

                        if (validators.servValidator(inputText))
                        {
                            System.Diagnostics.Debug.WriteLine("in Player " + p.Name + ", Editor = SERV, input text = " + inputText);
                            p.ServStats = inputText;
                            playerDatabase.UpdatePlayer(p);
                        }
                        else
                        {
                            DisplayAlert("Invalid", "Invalid Editor in Serv", "OK");
                            allOk = false;
                            break;
                        }

                    }
                    //field for reception
                    else if (statsEditor.ClassId == pname + 2)
                    {
                        if (statsEditor.Text == null)
                        {
                            inputText = "";
                        }
                        else
                        {
                            inputText = statsEditor.Text;
                        }

                        if (validators.receptionValidator(inputText))
                        {
                            System.Diagnostics.Debug.WriteLine("in Player " + p.Name + ", Editor = RECEPTION, input text = " + inputText);
                            p.ReceptionStats = inputText;
                            playerDatabase.UpdatePlayer(p);
                        }
                        else
                        {
                            DisplayAlert("Invalid", "Invalid input in Reception", "OK");
                            allOk = false;
                            break;
                        }

                    }
                    //field for attack
                    else if (statsEditor.ClassId == pname + 3)
                    {
                        if (statsEditor.Text == null)
                        {
                            inputText = "";
                        }
                        else
                        {
                            inputText = statsEditor.Text;
                        }

                        if (validators.attackValidator(inputText))
                        {
                            System.Diagnostics.Debug.WriteLine("in Player " + p.Name + ", Editor = ATTACK, input text = " + inputText);
                            p.AttackStats = inputText;
                            playerDatabase.UpdatePlayer(p);
                        }
                        else
                        {
                            DisplayAlert("Invalid", "Invalid input in Attacks", "OK");
                            allOk = false;
                            break;
                        }
                    }
                    //field for block
                    else if (statsEditor.ClassId == pname + 4)
                    {
                        if (statsEditor.Text == null)
                        {
                            inputText = "";
                        }
                        else
                        {
                            inputText = statsEditor.Text;
                        }
                        if (validators.blockValidator(inputText))
                        {
                            System.Diagnostics.Debug.WriteLine("in Player " + p.Name + ", BLOCK, input text = " + inputText);
                            p.BlockStats = inputText;
                            playerDatabase.UpdatePlayer(p);
                        }
                        else
                        {
                            DisplayAlert("Invalid", "Invalid input in Block, only + or k ", "OK");
                            allOk = false;
                            break;
                        }
                    }
                    //field for dig
                    else if (statsEditor.ClassId == pname + 5)
                    {
                        if (statsEditor.Text == null)
                        {
                            inputText = "";
                        }
                        else
                        {
                            inputText = statsEditor.Text;
                        }
                        if (validators.digValidator(inputText))
                        {
                            System.Diagnostics.Debug.WriteLine("in Player " + p.Name + ", Editor = DIG, input text = " + inputText);
                            p.DigStats = inputText;
                            playerDatabase.UpdatePlayer(p);
                        }
                        else
                        {
                            DisplayAlert("Invalid", "Invalid input in Digs", "OK");
                            allOk = false;
                            break;

                        }

                    }
                }
            }
            System.Diagnostics.Debug.WriteLine("Value of bool in check all: " + allOk);
            return allOk;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}