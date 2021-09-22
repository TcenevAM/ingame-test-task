using System;
using System.Collections.Generic;

namespace InGameTestTask.Dtos.ReadDtos
{
    public class ReadAuthorBooksDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<ReadGenresDto> Genres { get; set; } = new List<ReadGenresDto>();
        public string Edition { get; set; }
    }
}