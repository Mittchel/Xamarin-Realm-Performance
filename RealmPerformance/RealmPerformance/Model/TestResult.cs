using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmPerformance.Model
{
    public class TestResult : RealmObject
    {
        public int TestType { get; set; }

        public string WhoWon { get; set; }

        public long WinningMilliseconds { get; set; }

        public long SqlMilliseconds { get; set; }

        public long RealmMilliseconds { get; set; }
    }
}
