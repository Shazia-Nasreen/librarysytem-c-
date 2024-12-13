using System;
using librarysystem1.Models;

namespace librarysystem1
{
    class Program
    {
        static Library library = new Library();
        static Librarian currentLibrarian;
        static Borrower currentBorrower;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Library Management System");

            while (true)
            {
                Console.WriteLine("\nPlease choose your role:");
                Console.WriteLine("[1] Librarian ");
                Console.WriteLine("[2] Borrower");
                Console.WriteLine("[3] Exit");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        LoginAsLibrarian();
                        break;
                    case "2":
                        LoginAsBorrower();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        static void LoginAsLibrarian()
        {
            Console.WriteLine("Please enter the administrator username:");
            var username = Console.ReadLine();
            Console.WriteLine("Please enter the administrator password:");
            var password = Console.ReadLine();

            currentLibrarian = library.FindLibrarianByUsername(username);
            if (currentLibrarian != null && currentLibrarian.Password == password)
            {
                Console.WriteLine("Login successful!");
                LibrarianMenu();
            }
            else
            {
                Console.WriteLine("Incorrect username or password, please try again.");
            }
        }

        static void LoginAsBorrower()
        {
            Console.Write("Please enter the borrower's name: ");
            var name = Console.ReadLine();
            Console.Write("Please enter the borrower's password: ");
            var password = Console.ReadLine();

            currentBorrower = library.FindBorrowerByName(name);
            if (currentBorrower != null && currentBorrower.Password == password)
            {
                Console.WriteLine("Login successful.");
                BorrowerMenu();
            }
            else
            {
                Console.WriteLine("Login failed. Invalid name or password.");
            }
        }

        static void LibrarianMenu()
        {
            Console.WriteLine("Welcome to the Administrator Menu!");
            while (true)
            {
                Console.WriteLine("\nPlease choose an operation:");
                Console.WriteLine("[1] Add a book");
                Console.WriteLine("[2] Remove a book");
                Console.WriteLine("[3] Register a borrower");
                Console.WriteLine("[4] Deregister a borrower");
                Console.WriteLine("[5] Display all books");
                Console.WriteLine("[6] Display all borrowers");
                Console.WriteLine("[7] Exit");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddBook();
                        break;
                    case "2":
                        RemoveBook();
                        break;
                    case "3":
                        RegisterBorrower();
                        break;
                    case "4":
                        UnregisterBorrower();
                        break;
                    case "5":
                        library.DisplayAllBooks();
                        break;
                    case "6":
                        library.DisplayAllBorrowers();
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }
            }
        }

        static void BorrowerMenu()
        {
            Console.WriteLine("Welcome to the Borrower Menu!");
            while (true)
            {
                Console.WriteLine("\nPlease choose an operation:");
                Console.WriteLine("[1] Borrow a book");
                Console.WriteLine("[2] Return a book");
                Console.WriteLine("[3] View borrowed books");
                Console.WriteLine("[4] Exit");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        BorrowBook();
                        break;
                    case "2":
                        ReturnBook();
                        break;
                    case "3":
                        Console.WriteLine(currentBorrower);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid input, please try again.");
                        break;
                }
            }
        }

        static void AddBook()
        {
            Console.WriteLine("Please enter the book title:");
            var title = Console.ReadLine();
            Console.WriteLine("Please enter the author:");
            var author = Console.ReadLine();
            Console.WriteLine("Please enter the ISBN:");
            var isbn = Console.ReadLine();

            var book = new Book(title, author, isbn);
            currentLibrarian.AddBook(library, book);
        }

        static void RemoveBook()
        {
            Console.WriteLine("Please enter the title of the book to remove:");
            var title = Console.ReadLine();
            var book = library.FindBookByTitle(title);
            if (book != null)
            {
                currentLibrarian.RemoveBook(library, book);
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        static void RegisterBorrower()
        {
            Console.WriteLine("Please enter the borrower's name:");
            var name = Console.ReadLine();
            Console.WriteLine("Please enter the borrower's password:");
            var password = Console.ReadLine();
            var borrower = new Borrower(name, password);
            currentLibrarian.RegisterBorrower(library, borrower);
        }

        static void UnregisterBorrower()
        {
            Console.WriteLine("Please enter the name of the borrower to deregister:");
            var name = Console.ReadLine();
            var borrower = library.FindBorrowerByName(name);
            if (borrower != null)
            {
                currentLibrarian.RemoveBorrower(library, borrower);
            }
            else
            {
                Console.WriteLine("Borrower not found.");
            }
        }

        static void BorrowBook()
        {
            Console.WriteLine("Please enter the title of the book to borrow:");
            var title = Console.ReadLine();
            var book = library.FindBookByTitle(title);
            if (book != null)
            {
                currentBorrower.BorrowBook(book);
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        static void ReturnBook()
        {
            Console.WriteLine("Please enter the title of the book to return:");
            var title = Console.ReadLine();
            var book = library.FindBookByTitle(title);
            if (book != null)
            {
                currentBorrower.ReturnBook(book);
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
    }
}




