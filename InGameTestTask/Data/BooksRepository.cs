using System.Collections.Generic;
using System.Linq;
using InGameTestTask.Models;
using Microsoft.EntityFrameworkCore;

namespace InGameTestTask.Data
{
    public class BooksRepository : IBookRepository
    {
        private readonly Context _context;

        public BooksRepository(Context context)
        {
            _context = context;
        }

        public void CreateNewBook(Book newBook)
        {
            _context.Books.Add(newBook);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books
                .Include(b => b.Authors)
                .Include(b => b.Genres);
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _context.Genres.ToList();
        }

        public Book GetBook(int id)
        {
            return _context.Books
                .Include(b => b.Authors)
                .Include(b => b.Genres)
                .FirstOrDefault(b => b.Id == id);
        }

        public bool DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null) return false;
            _context.Books.Remove(book);
            return true;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}