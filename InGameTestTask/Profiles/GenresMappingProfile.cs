using AutoMapper;
using InGameTestTask.Dtos.ReadDtos;
using InGameTestTask.Models;

namespace InGameTestTask.Profiles
{
    public class GenresMappingProfile : Profile
    {
        public GenresMappingProfile()
        {
            CreateMap<Genre, ReadGenresDto>();
        }
    }
}