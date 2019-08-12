using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace boxScanner
{
    public partial class App : Application
    {
        static BoxDB database;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        public static BoxDB Database
        {
            get
            {
                if (database == null)
                {
                    database = new BoxDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BoxDB.db3"));
                }
                return database;
            }
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
