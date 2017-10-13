using RealmPerformance.Repositories;
using SQLite.Net.Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace RealmPerformance
{
    public partial class App : Application
    {
        private SQLiteRepository _sqlRepository;

        public App(SQLiteAsyncConnection connection)
        {
            InitializeComponent();

            _sqlRepository = new SQLiteRepository(connection);
            MainPage = new NavigationPage(new RealmPerformance.StartPage(_sqlRepository));
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
