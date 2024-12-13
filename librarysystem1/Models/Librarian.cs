using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using librarysystem1.Models;
namespace librarysystem1.Models
{
    using librarysystem1;

    public class Librarian
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public Librarian(string name, string password)
        {
            Name = name;
            Password = password;
        }

        public void AddBook(Library library, Book book)
        {
            library.Books.Add(book);
            Console.WriteLine($"Book added: {book.Title}");
            // Console.WriteLine($"Author: {book.Author}");
            // Console.WriteLine($"ISBN: {book.ISBN}");
            library.SaveBooksToFile();
        }

        public void RemoveBook(Library library, Book book)
        {
            if (library.Books.Contains(book))
            {
                library.Books.Remove(book);
                Console.WriteLine($"Book removed: {book.Title}");
                library.SaveBooksToFile();
            }
            else
            {
                Console.WriteLine($"Book not found: {book.Title}");
            }
        }

        public void RegisterBorrower(Library library, Borrower borrower)
        {
            library.Borrowers.Add(borrower);
            Console.WriteLine($"Borrower registered: {borrower.Name}");
            library.SaveBorrowersToFile();
        }

        public void RemoveBorrower(Library library, Borrower borrower)
        {
            if (library.Borrowers.Contains(borrower))
            {
                library.Borrowers.Remove(borrower);
                Console.WriteLine($"Borrower removed: {borrower.Name}");
                library.SaveBorrowersToFile();
            }
            else
            {
                Console.WriteLine("Borrower does not exist.");
            }
        }
    }
}