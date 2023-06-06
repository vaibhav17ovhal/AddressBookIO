using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace AddressBook
{
    public class Contact : IComparable<Contact>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public int CompareTo(Contact other)
        {
            if (other == null) 
                return 1;
            return string.Compare($"{FirstName} {LastName}", $"{other.FirstName} {other.LastName}", StringComparison.OrdinalIgnoreCase);
        }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}\n" +
                   $"Address: {Address}\n" +
                   $"City: {City}\n" +
                   $"State: {State}\n" +
                   $"ZIP: {Zip}\n" +
                   $"Phone: {PhoneNumber}\n" +
                   $"Email: {Email}\n";
        }
    }
}
