using RealmPerformance.Model.Realm;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace RealmPerformance.ViewModels
{
    public class ListViewViewModel
    {
        private Realm _realm;

        public ICommand AddEntryCommand { get; private set; }

        public IEnumerable<Person> Persons { get; private set; }

        public ListViewViewModel()
        {
            _realm = Realm.GetInstance();


            AddEntryCommand = new Command(AddEntry);
            this.Persons = _realm.All<Person>();
        }

        private void AddEntry()
        {
            _realm.Write(() =>
            {
                var person = _realm.CreateObject("Person");
                person.Id = 9999999;
                person.Name = "New";
                person.Age = 18;
                _realm.Add(person);
            });
        }
    }
}
