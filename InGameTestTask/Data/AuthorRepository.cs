using System.Collections.Generic;
using System.Linq;
using InGameTestTask.Models;
using Microsoft.EntityFrameworkCore;

namespace InGameTestTask.Data
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly Context _context;

        public AuthorRepository(Context context)
        {
            _context = context;
        }

        public void CreateAuthor(Author newAuthor)
        {
            _context.Authors.Add(newAuthor);
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _context.Authors
                .Include(a => a.Books)
                .ThenInclude(b => b.Genres);
        }

        public Author GetAuthor(int id)
        {
            var authors = _context.Authors
                .Include(a => a.Books)
                .ThenInclude(b => b.Genres);
            return authors.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Author> GetAuthorsByName(string name)
        {
            return _context.Authors.Where(a => a.Name == name);
        }

        public void DeleteAuthor(Author author)
        {
            _context.Authors.Remove(author);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}