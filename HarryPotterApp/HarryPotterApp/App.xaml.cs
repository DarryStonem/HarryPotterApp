using System;
using System.IO;
using Xamarin.Forms;
using HarryPotterApp.Data;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace HarryPotterApp
{
    public partial class App : Application
    {
        private static DatabaseContext context;

        public static DatabaseContext Context
        {
            get
            {
                if (context == null)
                {
                    var dbPath = Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),
                        "HarryPotterDB.db3");

                    context = new DatabaseContext(dbPath); 
                }

                return context;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new Views.CharactersListView());

            AppCenter.Start("android=49fdb20b-8e76-4ddb-bc0f-90d62a417362;",
                  typeof(Analytics), typeof(Crashes));
        }
    }
}
