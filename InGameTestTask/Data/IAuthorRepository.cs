using System.Collections.Generic;
using InGameTestTask.Models;

namespace InGameTestTask.Data
{
    public interface IAuthorRepository
    {
        void CreateAuthor(Author newAuthor);
        IEnumerable<Author> GetAllAuthors();
        Author GetAuthor(int id);
        IEnumerable<Author> GetAuthorsByName(string name);
        void DeleteAuthor(Author author);
        void SaveChanges();
    }
}