using System;
using System.Collections.Generic;

namespace InGameTestTask.Dtos.PatchDtos
{
    public class PatchAuthorDto : PatchDtoBase
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public List<int> Books { get; set; }
    }
}