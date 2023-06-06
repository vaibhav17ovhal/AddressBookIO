using System;

namespace AddressBook
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book I/O");

            AddressBookMain book = new AddressBookMain();
            book.Addcontact();
            Console.WriteLine("\n");
            book.Display();
            Console.WriteLine("\n");
            book.EditContact();
            Console.WriteLine("\n");
            book.Display();
            Console.WriteLine("\n");
            book.DeleteContact();
        }
    }
}
