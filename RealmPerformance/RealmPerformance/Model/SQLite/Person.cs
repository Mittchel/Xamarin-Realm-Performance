using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmPerformance.Model.SQlite
{

    public class Person
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public IList<Dog> Dogs { get; }
    }
}
