﻿using System;
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
        public PlayerDatabase playerDatabase;
        public Player player;
        public GameStatisticsPage ()
		{
			InitializeComponent ();
            //Fetching players from database
            playerDatabase = new PlayerDatabase();
            var players = playerDatabase.GetPlayers();
            players.ToList();

            //Setting backgroundcolor for mocking borders in our table
            BackgroundColor = Color.Black;

            var headerLabelStyle = new Style(typeof(Label))
            {
                Setters =
                {
                    new Setter{Property = Label.BackgroundColorProperty, Value = Color.White},
                    new Setter {Property = Label.TextColorProperty, Value = Color.Black},
                    new Setter{Property = Label.FontSizeProperty, Value = 40}
                }
            };
            //Style for labels
            var nameLabelStyle = new Style(typeof(Label))
            {
                Setters =
                {
                    new Setter{Property = Label.BackgroundColorProperty, Value = Color.White},
                    new Setter {Property = Label.TextColorProperty, Value = Color.Black},
                    new Setter{Property = Label.FontSizeProperty, Value = 30}
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
                var controlGrid = new Grid { RowSpacing = 1, ColumnSpacing = 1 };
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
                    controlGrid.Children.Add(new Label { Text = pName, Style = nameLabelStyle }, colNr, rowNr);
                    colNr++;
                    while(colNr < 6)
                    {
                        controlGrid.Children.Add(new Entry { Style = entryStyle }, colNr, rowNr);
                        colNr++;
                    }
                    colNr = 0;
                    rowNr++;
                }      

           Content = controlGrid;
            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}