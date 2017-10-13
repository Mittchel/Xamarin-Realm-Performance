using RealmPerformance.Repositories;
using RealmPerformance.ViewModels;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealmPerformance
{
	public partial class StartPage : ContentPage
	{
        private StartTestViewModel _viewModel;
        private Realm _realm;

        public StartPage(SQLiteRepository repository)
        {
            InitializeComponent();

            _realm = Realm.GetInstance();

            if (_viewModel == null)
                _viewModel = new StartTestViewModel(repository, _realm);

            this.BindingContext = _viewModel;
        }

        private async void TenThousandInsert_Clicked(object sender, EventArgs e)
        {
            var result = await _viewModel.InsertTenhousandItems().ConfigureAwait(false);

            string whoWonTitle = result.RealmMilliseconds < result.SqlMilliseconds ? "Realm won!" : "SQLite won!";
            string whoWonMessage = string.Format("Realm in ms: {0} \nSQLite in ms: {1}", result.RealmMilliseconds, result.SqlMilliseconds);

            Device.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert(whoWonTitle, whoWonMessage, "OK");
            });
        }

        private async void ThousandInsert_Clicked(object sender, EventArgs e)
        {
            var result = await _viewModel.InsertThousandItems().ConfigureAwait(false);

            string whoWonTitle = result.RealmMilliseconds < result.SqlMilliseconds ? "Realm won!" : "SQLite won!";
            string whoWonMessage = string.Format("Realm in ms: {0} \nSQLite in ms: {1}", result.RealmMilliseconds, result.SqlMilliseconds);

            Device.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert(whoWonTitle, whoWonMessage, "OK");
            });
        }

        private async void CountItem_Clicked(object sender, EventArgs e)
        {
            var realmCount =  _viewModel.GetCountRealm();
            var sqlCount = await _viewModel.GetCountSQlite();

            string alertMessage = string.Format("Realm: {0}\n SQlite: {1}", realmCount, sqlCount);

            await DisplayAlert("Count of objects", alertMessage, "OK");
        }

        private async void QueryTenThousand_Clicked(object sender, EventArgs e)
        {
            var result = await _viewModel.QueryTenThousandItems().ConfigureAwait(false);

            string whoWonTitle = result.RealmMilliseconds < result.SqlMilliseconds ? "Realm won!" : "SQLite won!";
            string whoWonMessage = string.Format("Realm in ms: {0} \nSQLite in ms: {1}", result.RealmMilliseconds, result.SqlMilliseconds);

            Device.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert(whoWonTitle, whoWonMessage, "OK");
            });
        }

        private async void QueryHundredThousand_Clicked(object sender, EventArgs e)
        {
            var result = await _viewModel.QueryTenThousandItems().ConfigureAwait(false);

            string whoWonTitle = result.RealmMilliseconds < result.SqlMilliseconds ? "Realm won!" : "SQLite won!";
            string whoWonMessage = string.Format("Realm in ms: {0} \nSQLite in ms: {1}", result.RealmMilliseconds, result.SqlMilliseconds);

            Device.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert(whoWonTitle, whoWonMessage, "OK");
            });
        }
    }
}