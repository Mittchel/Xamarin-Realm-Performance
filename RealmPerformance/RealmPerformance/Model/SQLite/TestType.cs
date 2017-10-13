using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmPerformance.Model.SQlite
{
    public enum TestType
    {
        TenThousandInsert = 1,
        HundredThousandInsert = 2,
        TenThousandQuery = 3,
        HundredThousandQuery = 4,
    }
}

