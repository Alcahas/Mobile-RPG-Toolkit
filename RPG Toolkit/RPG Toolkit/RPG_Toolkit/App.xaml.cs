using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace RPG_Toolkit
{
    public partial class App : Application
    {
        static PlayerDatabase database;

        public App()
        {
            InitializeComponent();
            
            MainPage = new HomePage();
        }

        

        public static PlayerDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new PlayerDatabase(DependencyService.Get<lLocalFileHelper>().GetLocalFilePath("Players.db3"));

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
