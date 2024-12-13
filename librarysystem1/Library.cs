using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using librarysystem1.Models;

namespace librarysystem1
{
    public class Library
    {
        public List<Book> Books { get; private set; } = new List<Book>();
        public List<Borrower> Borrowers { get; private set; } = new List<Borrower>();
        public List<Librarian> Librarians { get; private set; } = new List<Librarian>();

        // Hardcode the file paths
        private string BOOKS_FILE_PATH = @"C:\Users\sarah\OneDrive\Desktop\shazia\Tuc front end\Programming\librarysystem1\librarysystem1\books.txt";
        private string BORROWERS_FILE_PATH = @"C:\Users\sarah\OneDrive\Desktop\shazia\Tuc front end\Programming\librarysystem1\librarysystem1\Borrower.txt";
        private string LIBRARIANS_FILE_PATH = @"C:\Users\sarah\OneDrive\Desktop\shazia\Tuc front end\Programming\librarysystem1\librarysystem1\Librarian.txt";

        public Library()
        {
            LoadBooksFromFile();
            LoadBorrowersFromFile();
            LoadLibrariansFromFile();
        }

        // Save books to the file
        public void SaveBooksToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(BOOKS_FILE_PATH, false))
                {
                    foreach (var book in Books)
                    {
                        writer.WriteLine($"{book.Title}|{book.Author}|{book.ISBN}|{book.IsAvailable}");
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error saving books to file: {ex.Message}");
            }
        }

        // Save borrowers to the file
        public void SaveBorrowersToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(BORROWERS_FILE_PATH, false))
                {
                    foreach (var borrower in Borrowers)
                    {
                        writer.WriteLine($"{borrower.Name}|{borrower.Password}");
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error saving borrowers to file: {ex.Message}");
            }
        }

        // Save librarians to the file
        public void SaveLibrariansToFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(LIBRARIANS_FILE_PATH, false))
                {
                    foreach (var librarian in Librarians)
                    {
                        writer.WriteLine($"{librarian.Name}|{librarian.Password}");
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error saving librarians to file: {ex.Message}");
            }
        }

        // Load books from the file
        public void LoadBooksFromFile()
        {
            if (File.Exists(BOOKS_FILE_PATH))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(BOOKS_FILE_PATH))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            var parts = line.Split('|');
                            if (parts.Length == 4)
                            {
                                Books.Add(new Book(parts[0], parts[1], parts[2], bool.Parse(parts[3])));
                            }
                        }
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Error loading books from file: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Books file not found. Ensure the file exists.");
            }
        }

        //  here Load borrowers from the file
        public void LoadBorrowersFromFile()
        {
            if (File.Exists(BORROWERS_FILE_PATH))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(BORROWERS_FILE_PATH))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            var parts = line.Split('|');
                            if (parts.Length == 2)
                            {
                                Borrowers.Add(new Borrower(parts[0], parts[1]));
                            }
                        }
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Error loading borrowers from file: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Borrowers file not found. Ensure the file exists.");
            }
        }

        // Load librarians from the file
        public void LoadLibrariansFromFile()
        {
            if (File.Exists(LIBRARIANS_FILE_PATH))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(LIBRARIANS_FILE_PATH))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            var parts = line.Split('|');
                            if (parts.Length == 2)
                            {
                                Librarians.Add(new Librarian(parts[0], parts[1]));
                            }
                        }
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Error loading librarians from file: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Librarians file not found. Ensure the file exists.");
            }
        }

        // Display all books
        public void DisplayAllBooks()
        {
            Console.WriteLine("All Books in the Library:");
            foreach (var book in Books)
            {
                Console.WriteLine($"{book.Title} by {book.Author}, ISBN: {book.ISBN}, Available: {book.IsAvailable}");
            }
        }

        // Display all borrowers
        public void DisplayAllBorrowers()
        {
            Console.WriteLine("All Borrowers:");
            foreach (var borrower in Borrowers)
            {
                Console.WriteLine($"{borrower.Name}");
            }
        }

        // Find a book by title
        public Book FindBookByTitle(string title)
        {
            return Books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        // Find a borrower by name
        public Borrower FindBorrowerByName(string name)
        {
            return Borrowers.FirstOrDefault(b => b.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        // Find a librarian by username
        public Librarian FindLibrarianByUsername(string username)
        {
            return Librarians.FirstOrDefault(l => l.Name.Equals(username, StringComparison.OrdinalIgnoreCase));
        }
    }
}
