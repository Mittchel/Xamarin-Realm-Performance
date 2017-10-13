using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmPerformance.Model.Realm
{

    public class Person : RealmObject
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
