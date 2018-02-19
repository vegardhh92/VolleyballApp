using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VolleyballApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ViewGameStatsPage : ContentPage
	{
        private db.Database database;
        private db.Game game;
        //private ObservableCollection<db.Player> playersObs;

		public ViewGameStatsPage (int gameId)
		{
			InitializeComponent ();

            // Get game from sent Id
            database = new db.Database();
            game = database.GetGameFromId(gameId);

            // Set elements
            title.Text = game.Description;
            gameScore.Text = "Game score: " + game.GameScore;

            // Add players to table if they exist
            if (game.Players.Count > 0) { GenerateTable(); }
		}

        /**
         * Fills the grids defined in XAML
         * with data from the players. Calls FillHeader()
         * which creates header with description columns and
         * then fills in the data with FillData().
         */
        public void GenerateTable()
        {
            FillHeader();
            FillData();
        }

        private void FillData()
        {
            // Column
            data.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            data.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            data.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            data.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            data.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            data.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            // Row
            int rowNumber = 0;
            foreach(db.Player player in game.Players)
            {
                // Add new row
                data.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

                // Get calculated game-stats
                string servEfficiency = (Utils.GameCalc.ServEfficiency(player.ServStats)*100.0).ToString() + "%";
                string avgReception = Utils.GameCalc.AvgReception(player.ReceptionStats).ToString();
                string attackEfficiency = (Utils.GameCalc.AttackEfficiency(player.AttackStats)*100.0).ToString() + "%";

                // Populate
                data.Children.Add(new Label { Text = player.Name },         0, rowNumber);
                data.Children.Add(new Label { Text = servEfficiency },      1, rowNumber);
                data.Children.Add(new Label { Text = avgReception },        2, rowNumber);
                data.Children.Add(new Label { Text = attackEfficiency },    3, rowNumber);
                data.Children.Add(new Label { Text = player.BlockStats },   4, rowNumber);
                data.Children.Add(new Label { Text = player.DigStats },     5, rowNumber);

                // Increment row counter
                rowNumber++;
            }
        }

        private void FillHeader()
        {
            // Row
            headers.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            // Column
            headers.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            headers.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            headers.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            headers.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            headers.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            headers.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            // Header text
            headers.Children.Add(new Label { Text = "Name",     FontAttributes = FontAttributes.Bold }, 0, 0);
            headers.Children.Add(new Label { Text = "Serv Efficiency",     FontAttributes = FontAttributes.Bold }, 1, 0);
            headers.Children.Add(new Label { Text = "Reception Average",FontAttributes = FontAttributes.Bold }, 2, 0);
            headers.Children.Add(new Label { Text = "Attack Efficiency",   FontAttributes = FontAttributes.Bold }, 3, 0);
            headers.Children.Add(new Label { Text = "Block",    FontAttributes = FontAttributes.Bold }, 4, 0);
            headers.Children.Add(new Label { Text = "Dig",      FontAttributes = FontAttributes.Bold }, 5, 0);
        }
	}
}