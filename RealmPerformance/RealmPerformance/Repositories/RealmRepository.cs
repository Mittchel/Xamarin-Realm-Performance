using RealmPerformance.Model;
using RealmPerformance.Model.Realm;
using Realms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmPerformance.Repositories
{
    public class RealmRepository
    {
        private Realm _realm;

        public RealmRepository(Realm realm)
        {
            _realm = realm;
        }

        public void Clear()
        {
            _realm.Write(() =>
            {
                _realm.RemoveAll<TestResult>();
                _realm.RemoveAll<Person>();
            });
        }

        public long InsertThousandItems()
        {
            var watch = Stopwatch.StartNew();

            _realm.Write(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    var person = _realm.CreateObject("Person");
                    person.Name = $"Dog {i}";
                    person.Age = 18;
                    _realm.Add(person);
                }
            });
            watch.Stop();
            return watch.ElapsedMilliseconds;
        }

        public long InsertTenThousandItems()
        {
            var watch = Stopwatch.StartNew();

            _realm.Write(() =>
            {
                for (int i = 0; i < 10000; i++)
                {
                    var person = _realm.CreateObject("Person");
                    person.Id = i;
                    person.Name = $"Dog {i}";
                    person.Age = 18;
                    _realm.Add(person);
                }
            });

            watch.Stop();
            return watch.ElapsedMilliseconds;
        }

        public long QueryThousand()
        {
            Clear();
            InsertThousandItems();
  
            var watch = Stopwatch.StartNew();

            var results = _realm.All<Person>().Where(c => c.Id > 0).ToList();

            watch.Stop();

            System.Diagnostics.Debug.WriteLine($"Elapsed: {watch.ElapsedMilliseconds}");
            return watch.ElapsedMilliseconds;
        }

        public long QueryTenThousand()
        {
            Clear();
            InsertTenThousandItems();

            var watch = Stopwatch.StartNew();

            var results = _realm.All<Person>().Where(c => c.Id > 0).ToList();

            watch.Stop();

            System.Diagnostics.Debug.WriteLine($"Elapsed: {watch.ElapsedMilliseconds}");
            return watch.ElapsedMilliseconds;
        }

        internal int GetCount()
        {
            return _realm.All<Person>().Count();
        }
    }
}
