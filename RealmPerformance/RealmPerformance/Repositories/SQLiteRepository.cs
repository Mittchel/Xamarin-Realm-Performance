using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Async;
using RealmPerformance.Model.SQlite;
using SQLite.Net;
using System.Diagnostics;

namespace RealmPerformance.Repositories
{
    public class SQLiteRepository
    {
        private readonly SQLiteAsyncConnection _connection;

        public SQLiteRepository(SQLiteAsyncConnection connection)
        {
            _connection = connection;

            _connection.DropTableAsync<Person>().Wait();
            _connection.CreateTableAsync<Person>().Wait();
        }

        public async Task Clear()
        {
            try
            {
                await _connection.DeleteAllAsync<Person>();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }
        }

        public async Task<long> InsertThousandItems()
        {
            List<Person> persons = new List<Person>();

            for (int i = 0; i < 1000; i++)
            {
                persons.Add(new Person()
                {
                    Id = i,
                    Name= $"Dog {i}",
                    Age = 18
                });
            }

            var watch = Stopwatch.StartNew();

            await _connection.RunInTransactionAsync((SQLiteConnection conn) =>
            {
                conn.InsertAll(persons);
            });

            watch.Stop();

            return watch.ElapsedMilliseconds;
        }

        public async Task<long> InsertTenThousandItems()
        {
            List<Person> persons = new List<Person>();

            for (int i = 0; i < 10000; i++)
            {
                persons.Add(new Person()
                {
                    Id = i,
                    Name = $"Dog {i}",
                    Age = 18
                });
            }

            var watch = Stopwatch.StartNew();

            await _connection.RunInTransactionAsync((SQLiteConnection conn) =>
            {
                conn.InsertAll(persons);
            });

            watch.Stop();

            return watch.ElapsedMilliseconds;
        }

        internal Task<int> GetCount()
        {
            return _connection.Table<Person>().CountAsync();
        }

        public async Task<long> QueryTenThousand()
        {
            var watch = Stopwatch.StartNew();

            await Clear();
            await InsertTenThousandItems();

            watch = Stopwatch.StartNew();

            var results = await _connection.Table<Person>().Where(c => c.Id > 0).ToListAsync();

            watch.Stop();

            return watch.ElapsedMilliseconds;
        }

        public async Task<long> QueryThousand()
        {
            await Clear();
            await InsertThousandItems();

            var watch = Stopwatch.StartNew();

            var results = await _connection.Table<Person>().Where(c => c.Id > 0).ToListAsync();

            watch.Stop();

            return watch.ElapsedMilliseconds;
        }
    }
}
