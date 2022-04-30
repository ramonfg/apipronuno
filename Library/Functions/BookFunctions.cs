using System.Collections.Generic;
using System.Linq;
using Library.Models;

namespace Library.Functions
{
    public class BookFunctions
    {
        private readonly File File;
        private List<Book> Books;
        public BookFunctions()
        {
            this.File = new File();
            this.Books = new List<Book>();
        }
        public int GetHighestId()
        {
            GetBooks();
            int highest = 0;
            foreach (Book b in this.Books)
            {
                if (b.Id > highest) highest = b.Id;
            }
            return highest;
        }
        public IEnumerable<Book> GetBooks()
        {
            this.Books = File.GetBooks();
            return this.Books;
        }
        public void SaveBooks()
        {
            File.SetBooks(this.Books);
        }
        public Book GetBook(int id)
        {
            GetBooks();
            return this.Books.Where(book => book.Id == id).SingleOrDefault();
        }
        public List<Book> SearchBook(string text)
        {
            GetBooks();
            return this.Books.Where(book => book.Name.ToLower().Contains(text.ToLower()) 
                || book.Author.ToLower().Contains(text.ToLower())).ToList<Book>();
        }
        public void AddBook(Book b)
        {
            GetBooks();
            this.Books.Add(b);
            SaveBooks();
        }
        public bool EditBook(Book b)
        {
            GetBooks();
            Book found = this.Books.Where(book => book.Id == b.Id).SingleOrDefault();
            if(found is null) return false;
            else 
            {
                this.Books = this.Books.Where(book => book.Id != b.Id).ToList<Book>();
                this.Books.Add(b);
                SaveBooks();
                return true;
            }
        }
        public bool DeleteBook(int id)
        {
            GetBooks();
            List<Book> found = this.Books.Where(book => book.Id == id).ToList<Book>();
            if(found.Count == 0) return false;
            else 
            {
                this.Books = this.Books.Where(book => book.Id != id).ToList<Book>();
                SaveBooks();
                return true;
            }
        }
        public void DeleteBooks()
        {
            this.Books = new List<Book>();
            SaveBooks();
        }
    }
}