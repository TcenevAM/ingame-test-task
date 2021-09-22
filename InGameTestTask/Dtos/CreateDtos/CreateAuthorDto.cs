using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InGameTestTask.Dtos.CreateDtos
{
    public class CreateAuthorDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public List<int> Books { get; set; }
    }
}