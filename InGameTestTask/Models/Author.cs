using System;
using System.Collections.Generic;

namespace InGameTestTask.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
    }
}