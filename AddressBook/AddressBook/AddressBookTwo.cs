using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class AddressBookTwo
    {
        private List<Address> addressBooks = new List<Address>();
        public void CreateAddressBook()
        {
            Console.WriteLine("Enter the name for the new address book:");
            string bookName = Console.ReadLine();

            if (addressBooks.Any(ab => ab.Name.Equals(bookName, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("An address book with the same name already exists.");
                return;
            }

            Address addressBook = new Address(bookName);
            addressBooks.Add(addressBook);

            Console.WriteLine("Address book created successfully.");
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
            allContacts.Sort((c1, c2) => string.Compare($"{c1.FirstName} {c1.LastName}", $"{c2.FirstName} {c2.LastName}", StringComparison.OrdinalIgnoreCase));

            Console.WriteLine("Sorted contacts by name:");
            Console.WriteLine("----------------------------------");

            foreach (var contact in allContacts)
            {
                Console.WriteLine(contact);
                Console.WriteLine("----------------------------------");
            }
        }
        public void SortContactsByCity()
        {
            List<Contact> allContacts = addressBooks.SelectMany(ab => ab.Contacts).ToList();
            allContacts = allContacts.OrderBy(c => c.City).ToList();

            Console.WriteLine("Sorted contacts by city:");
            Console.WriteLine("----------------------------------");

            foreach (var contact in allContacts)
            {
                Console.WriteLine(contact);
                Console.WriteLine("----------------------------------");
            }
        }
        public void SortContactsByState()
        {
            List<Contact> allContacts = addressBooks.SelectMany(ab => ab.Contacts).ToList();
            allContacts = allContacts.OrderBy(c => c.State).ToList();

            Console.WriteLine("Sorted contacts by state:");
            Console.WriteLine("----------------------------------");

            foreach (var contact in allContacts)
            {
                Console.WriteLine(contact);
                Console.WriteLine("----------------------------------");
            }
        }
        public void SortContactsByZip()
        {
            List<Contact> allContacts = addressBooks.SelectMany(ab => ab.Contacts).ToList();
            allContacts = allContacts.OrderBy(c => c.Zip).ToList();

            Console.WriteLine("Sorted contacts by ZIP:");
            Console.WriteLine("----------------------------------");

            foreach (var contact in allContacts)
            {
                Console.WriteLine(contact);
                Console.WriteLine("----------------------------------");
            }
        }
        public void SaveToFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var addressBook in addressBooks)
                {
                    writer.WriteLine($"Address Book: {addressBook.Name}");
                    writer.WriteLine("----------------------------------");

                    foreach (var contact in addressBook.Contacts)
                    {
                        writer.WriteLine(contact);
                        writer.WriteLine("----------------------------------");
                    }
                }
            }

            Console.WriteLine($"Address book saved to file: {fileName}");
        }
        public void LoadFromFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"File not found: {fileName}");
                return;
            }

            addressBooks.Clear();

            Address currentAddressBook = null;
            Contact currentContact = null;

            foreach (string line in File.ReadLines(fileName))
            {
                if (line.StartsWith("Address Book:"))
                {
                    string addressBookName = line.Substring(line.IndexOf(':') + 1).Trim();
                    currentAddressBook = new Address(addressBookName);
                    addressBooks.Add(currentAddressBook);
                }
                else if (line.StartsWith("Name:"))
                {
                    currentContact = new Contact();
                    currentContact.FirstName = line.Substring(line.IndexOf(':') + 1).Trim();
                }
                else if (currentContact != null)
                {
                    if (line.StartsWith("Address:"))
                        currentContact.Address = line.Substring(line.IndexOf(':') + 1).Trim();
                    else if (line.StartsWith("City:"))
                        currentContact.City = line.Substring(line.IndexOf(':') + 1).Trim();
                    else if (line.StartsWith("State:"))
                        currentContact.State = line.Substring(line.IndexOf(':') + 1).Trim();
                    else if (line.StartsWith("ZIP:"))
                        currentContact.Zip = line.Substring(line.IndexOf(':') + 1).Trim();
                    else if (line.StartsWith("Phone:"))
                        currentContact.PhoneNumber = line.Substring(line.IndexOf(':') + 1).Trim();
                    else if (line.StartsWith("Email:"))
                    {
                        currentContact.Email = line.Substring(line.IndexOf(':') + 1).Trim();
                        currentAddressBook.Contacts.Add(currentContact);
                        currentContact = null;
                    }
                }
            }

            Console.WriteLine($"Address book loaded from file: {fileName}");
        }

        public void SaveToCsv(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var addressBook in addressBooks)
                {
                    writer.WriteLine($"Address Book: {addressBook.Name}");
                    writer.WriteLine("First Name,Last Name,Address,City,State,ZIP,Phone,Email");

                    foreach (var contact in addressBook.Contacts)
                    {
                        writer.WriteLine(contact);
                    }
                }
            }

            Console.WriteLine($"Address book saved as CSV file: {fileName}");
        }
        public void LoadFromCsv(string fileName)
        {
            if (!File.Exists(fileName))
            {
                Console.WriteLine($"File not found: {fileName}");
                return;
            }

            addressBooks.Clear();

            Address currentAddressBook = null;
            bool isFirstLine = true;

            foreach (string line in File.ReadLines(fileName))
            {
                if (line.StartsWith("Address Book:"))
                {
                    string addressBookName = line.Substring(line.IndexOf(':') + 1).Trim();
                    currentAddressBook = new Address(addressBookName);
                    addressBooks.Add(currentAddressBook);
                }
                else if (!isFirstLine)
                {
                    string[] values = line.Split(',');
                    if (values.Length == 8)
                    {
                        Contact contact = new Contact
                        {
                            FirstName = values[0],
                            LastName = values[1],
                            Address = values[2],
                            City = values[3],
                            State = values[4],
                            Zip = values[5],
                            PhoneNumber = values[6],
                            Email = values[7]
                        };

                        currentAddressBook.Contacts.Add(contact);
                    }
                }

                isFirstLine = false;
            }

            Console.WriteLine($"Address book loaded from CSV file: {fileName}");
        }
    }
}


