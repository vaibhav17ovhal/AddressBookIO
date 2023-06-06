using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class Address
    {
        public string Name { get; set; }
        public Collection<Contact> Contacts { get; set; } = new Collection<Contact>();

        public Address(string name)
        {
            Name = name;
        }
    }
}
