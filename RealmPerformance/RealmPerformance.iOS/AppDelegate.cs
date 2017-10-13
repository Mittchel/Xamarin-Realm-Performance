using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using SQLite.Net;
using SQLite.Net.Async;

namespace RealmPerformance.iOS
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            string dbPath = GetDatabasePath("RealmPerformance.db");
            var param = new SQLiteConnectionString(dbPath, false);
            var connection = new SQLiteAsyncConnection(() => new SQLiteConnectionWithLock(platform, param));
            LoadApplication(new RealmPerformance.App(connection));

            return base.FinishedLaunching(app, options);
        }

        private string GetDatabasePath(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(path, filename);
        }
    }
}
