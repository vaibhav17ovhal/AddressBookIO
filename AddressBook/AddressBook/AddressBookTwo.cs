using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class AddressBookTwo
    {
        private List<Address> addressBooks;


        public AddressBookTwo()
        {
            addressBooks = new List<Address>();
        }
        public void CreateAddressBook()
        {
            Console.WriteLine("Enter a unique name for the address book:");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Invalid name. Please try again.");
                return;
            }

            if (addressBooks.Exists(ab => ab.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine($"Address book '{name}' already exists.");
                return;
            }

            addressBooks.Add(new Address(name));
            Console.WriteLine($"Address book '{name}' created successfully.");
        }
        public void AddContact()
        {
            Console.WriteLine("Enter the address book name:");
            string bookName = Console.ReadLine();

            Address addressBook = addressBooks.FirstOrDefault(ab => ab.Name.Equals(bookName, StringComparison.OrdinalIgnoreCase));
            if (addressBook == null)
            {
                Console.WriteLine("Address book not found.");
                return;
            }

            Contact contact = new Contact();

            Console.WriteLine("Enter the first name:");
            contact.FirstName = Console.ReadLine();

            Console.WriteLine("Enter the last name:");
            contact.LastName = Console.ReadLine();

            Console.WriteLine("Enter the address:");
            contact.Address = Console.ReadLine();

            Console.WriteLine("Enter the city:");
            contact.City = Console.ReadLine();

            Console.WriteLine("Enter the state:");
            contact.State = Console.ReadLine();

            Console.WriteLine("Enter the ZIP:");
            contact.Zip = Console.ReadLine();

            Console.WriteLine("Enter the phone number:");
            contact.PhoneNumber = Console.ReadLine();

            Console.WriteLine("Enter the email:");
            contact.Email = Console.ReadLine();

            addressBook.Contacts.Add(contact);

            Console.WriteLine("Contact added successfully.");
        }

        public void DisplayAllContacts()
        {
            foreach (var addressBook in addressBooks)
            {
                Console.WriteLine($"Address Book: {addressBook.Name}");
                Console.WriteLine("----------------------------------");

                foreach (var contact in addressBook.Contacts)
                {
                    Console.WriteLine(contact);
                    Console.WriteLine("----------------------------------");
                }
            }
        }
        public void SearchPerson()
        {
            Console.WriteLine("Enter the city or state to search:");
            string searchQuery = Console.ReadLine();

            List<Contact> searchResults = new List<Contact>();

            foreach (var addressBook in addressBooks)
            {
                foreach (var contact in addressBook.Contacts)
                {
                    if (contact.City.Equals(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                        contact.State.Equals(searchQuery, StringComparison.OrdinalIgnoreCase))
                    {
                        searchResults.Add(contact);
                    }
                }
            }
            if (searchResults.Count > 0)
            {
                Console.WriteLine($"Search results for '{searchQuery}':");
                Console.WriteLine("----------------------------------");
                foreach (var contact in searchResults)
                {
                    Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                    Console.WriteLine($"Address: {contact.Address}");
                    Console.WriteLine($"City: {contact.City}");
                    Console.WriteLine($"State: {contact.State}");
                    Console.WriteLine($"ZIP: {contact.Zip}");
                    Console.WriteLine($"Phone: {contact.PhoneNumber}");
                    Console.WriteLine($"Email: {contact.Email}");
                    Console.WriteLine("----------------------------------");
                }
            }
            else
            {
                Console.WriteLine($"No results found for '{searchQuery}'.");
            }
        }
        public void ViewPersonsByCityOrState()
        {
            Console.WriteLine("Enter the city or state to view persons:");
            string searchQuery = Console.ReadLine();

            List<Contact> searchResults = new List<Contact>();

            foreach (var addressBook in addressBooks)
            {
                foreach (var contact in addressBook.Contacts)
                {
                    if (contact.City.Equals(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                        contact.State.Equals(searchQuery, StringComparison.OrdinalIgnoreCase))
                    {
                        searchResults.Add(contact);
                    }
                }
            }

            int count = searchResults.Count;

            if (count > 0)
            {
                Console.WriteLine($"Persons in '{searchQuery}':");
                Console.WriteLine("----------------------------------");
                foreach (var contact in searchResults)
                {
                    Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                    Console.WriteLine($"Address: {contact.Address}");
                    Console.WriteLine($"City: {contact.City}");
                    Console.WriteLine($"State: {contact.State}");
                    Console.WriteLine($"ZIP: {contact.Zip}");
                    Console.WriteLine($"Phone: {contact.PhoneNumber}");
                    Console.WriteLine($"Email: {contact.Email}");
                    Console.WriteLine("----------------------------------");
                }
                Console.WriteLine($"Total persons: {count}");
            }
            else
            {
                Console.WriteLine($"No persons found in '{searchQuery}'.");
            }
        }
        public void SortContactsByName()
        {
            List<Contact> allContacts = addressBooks.SelectMany(ab => ab.Contacts).ToList();
            allContacts.Sort();

            Console.WriteLine("Sorted contacts by name:");
            Console.WriteLine("----------------------------------");

            foreach (var contact in allContacts)
            {
                Console.WriteLine(contact);
                Console.WriteLine("----------------------------------");
            }
        }
    }
}