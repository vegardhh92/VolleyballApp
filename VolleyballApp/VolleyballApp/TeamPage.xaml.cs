using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;
namespace VolleyballApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeamPage : ContentPage
    {
        public TeamPage()
        {
            InitializeComponent();
        }

        public void Save_Button_Clicked(object sender, EventArgs e)
        {
            string numberFromInput = numberEntry.Text;

            Player player = new Player()
            {

                number = Convert.ToInt32(numberFromInput),
                name = nameEntry.Text,
                position = positionEntry.Items[positionEntry.SelectedIndex]
            };
            DisplayAlert("Success", numberEntry.Text + player.name + player.position, "Great");
        }
    }
}/*
        public static string getDBPath()
        {
            
            var sqliteFileName = "TaskDB.db3";

#if SILVERLIGHT
    // Windows Phone 8
    var path = filename;
#else

#if __ANDROID__
    string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); ;
#else

            // UWP
            string libraryPath = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
#endif
#endif
            var path = Path.Combine(libraryPath, sqliteFileName);
#endif
            return path;
        }
    }
}
*/