using System.Collections.Generic;
using InGameTestTask.Models;

namespace InGameTestTask.Data
{
    public interface IBookRepository
    {
        void CreateNewBook(Book newBook);
        IEnumerable<Book> GetAllBooks();
        IEnumerable<Genre> GetAllGenres();
        Book GetBook(int id);
        bool DeleteBook(int id);
        void SaveChanges();
    }
}