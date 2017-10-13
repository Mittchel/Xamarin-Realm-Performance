using RealmPerformance.Model;
using RealmPerformance.Model.Realm;
using RealmPerformance.Repositories;
using Realms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace RealmPerformance.ViewModels
{
    public class StartTestViewModel
    {
        private RealmRepository _realmRepository;
        private SQLiteRepository _sqliteRepository;
        private Realm _realm;

        public StartTestViewModel(SQLiteRepository repository, Realm realm)
        {
            _realm = realm;
            _realmRepository = new RealmRepository(realm);
            _sqliteRepository = repository;
            _realmRepository.Clear();
        }

        public IEnumerable<TestResult> TestResults
        {
            get;
            private set;
        }

        public async Task<TestResult> InsertThousandItems()
        {
            TestResult testResult = new TestResult();
            testResult.TestType = (int)TestType.ThousandInsert;

            _realmRepository.Clear();
            await _sqliteRepository.Clear();

            // Insert result for realm
            var realmResult = _realmRepository.InsertThousandItems();

            // Insert result for Sqlite
            var sqlResult = await _sqliteRepository.InsertThousandItems();

            testResult.RealmMilliseconds = realmResult;
            testResult.SqlMilliseconds = sqlResult;

            return testResult;
        }

        internal Task<int> GetCountSQlite()
        {
            return _sqliteRepository.GetCount();
        }

        internal int GetCountRealm()
        {
            return _realmRepository.GetCount();
        }

        public async Task<TestResult> InsertTenhousandItems()
        {
            var testResult = new TestResult();
            testResult.TestType = (int)TestType.TenThousandInsert;

            _realmRepository.Clear();
            await _sqliteRepository.Clear();

            // Insert result for realm
            var realmResult = _realmRepository.InsertTenThousandItems();


            // Insert result for Sqlite
            var sqlResult = await _sqliteRepository.InsertTenThousandItems();

            // Save testresult
            testResult.RealmMilliseconds = realmResult;
            testResult.SqlMilliseconds = sqlResult;

            return testResult;
        }

        public async Task<TestResult> QueryThousandItems()
        {
            var testResult = new TestResult();
            testResult.TestType = (int)TestType.ThousandQuery;

            // Insert result for realm
            var realmResult = _realmRepository.QueryThousand();


            // Insert result for Sqlite
            var sqlResult = await _sqliteRepository.QueryThousand();

            // Save testresult
            testResult.RealmMilliseconds = realmResult;
            testResult.SqlMilliseconds = sqlResult;

            return testResult;
        }

        public async Task<TestResult> QueryTenThousandItems()
        {
            var testResult = new TestResult();
            testResult.TestType = (int)TestType.TenThousandQuery;

            // Insert result for realm
            var realmResult = _realmRepository.QueryTenThousand();


            // Insert result for Sqlite
            var sqlResult = await _sqliteRepository.QueryTenThousand();

            // Save testresult
            testResult.RealmMilliseconds = realmResult;
            testResult.SqlMilliseconds = sqlResult;

            return testResult;
        }
    }
}
