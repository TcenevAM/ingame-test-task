using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InGameTestTask.Dtos.CreateDtos
{
    public class CreateBookDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public List<int> Genres { get; set; }
        [Required]
        public List<int> Authors { get; set; }
        [Required]
        public string Edition { get; set; }
    }
}