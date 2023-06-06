﻿using System;

namespace AddressBook
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book I/O");
            /*
            AddressBookMain book = new AddressBookMain();
            Console.Write("Enter the number of contact you want to save: ");
            int num = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= num; i++)
            {
                book.Addcontact();
                Console.WriteLine("\n");
                book.Display();
                Console.WriteLine("\n");
            }
            
            Console.WriteLine("\n");
            book.EditContact();
            Console.WriteLine("\n");
            book.Display();
            Console.WriteLine("\n");
            book.DeleteContact();
            */

            AddressBookTwo two = new AddressBookTwo();
            

            while (true)
            {
                Console.WriteLine("1. Create address book");
                Console.WriteLine("2. Add contact");
                Console.WriteLine("3. Display all contacts");
                Console.WriteLine("4. Search person in a city or state");
                Console.WriteLine("5. View Person by entering city or state");
                Console.WriteLine("6. Sort contacts by name");
                Console.WriteLine("7. Sort contacts by city");
                Console.WriteLine("8. Sort contacts by state");
                Console.WriteLine("9. Sort contacts by Zip");
                Console.WriteLine("10. Save address book to file");
                Console.WriteLine("11. Load address book from file");
                Console.WriteLine("12. Exit");
                Console.WriteLine("Enter your choice:");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        two.CreateAddressBook();
                        break;
                    case 2:
                        two.AddContact();
                        break;
                    case 3:
                        two.DisplayAllContacts();
                        break;
                    case 4:
                        two.SearchPerson();
                        break;
                    case 5:
                        two.ViewPersonsByCityOrState();
                        break;
                    case 6:
                        two.SortContactsByName();
                        break;
                    case 7:
                        two.SortContactsByName();
                        break;
                    case 8:
                        two.SortContactsByName();
                        break;
                    case 9:
                        two.SortContactsByName();
                        break;
                    case 10:
                        Console.WriteLine("Enter the file name to save: ");
                        string saveFileName = Console.ReadLine();
                        two.SaveToFile(saveFileName);
                        break;
                    case 11:
                        Console.WriteLine("Enter the file name to load: ");
                        string loadFileName = Console.ReadLine();
                        two.LoadFromFile(loadFileName);
                        break;
                    case 12:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
