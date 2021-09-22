using System;
using System.Collections.Generic;
using InGameTestTask.Models;

namespace InGameTestTask.Dtos.PatchDtos
{
    public class PatchBookDto : PatchDtoBase
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<Genre> Genres { get; set; } = new List<Genre>();
        public List<Author> Authors { get; set; } = new List<Author>();
        public string Edition { get; set; }
    }
}