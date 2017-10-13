using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmPerformance.Model.SQlite
{
    // Dog model
    public class Dog 
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person Owner { get; set; }
    }
}
