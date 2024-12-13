using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
namespace librarysystem1.Models





{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool IsAvailable { get; set; } = true;
        public Book(string title, string author, string isbn)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
        }
        public Book(string title, string author, string isbn, bool isAvailable)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            IsAvailable = isAvailable;

        }

        public void Borrow()
        {
            IsAvailable = false;
        }

        public void Return()
        {
            IsAvailable = true;
        }

        public override string ToString()
        {
            return $"{Title} by {Author} with ISBN: {ISBN}";
        }

        
    }
}