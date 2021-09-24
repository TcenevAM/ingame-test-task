using System.Collections.Generic;
using AutoMapper;
using InGameTestTask.Dtos.CreateDtos;
using InGameTestTask.Dtos.PatchDtos;
using InGameTestTask.Dtos.ReadDtos;
using InGameTestTask.Models;

namespace InGameTestTask.Profiles
{
    public class AuthorsMappingProfile : Profile
    {
        public AuthorsMappingProfile()
        {
            CreateMap<CreateAuthorDto, Author>()
                .ForMember(dest => dest.Books,
                    opt => opt.ConvertUsing<IntConverter<Book>, List<int>>());
            CreateMap<PatchAuthorDto, Author>()
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(
                        (src, dest) =>
                            src.IsFieldPresent(nameof(src.Name)) ? src.Name : dest.Name))
                .ForMember(dest => dest.BirthDate,
                    opt => opt.MapFrom(
                        (src, dest) =>
                            src.IsFieldPresent(nameof(src.BirthDate)) ? src.BirthDate : dest.BirthDate))
                .ForMember(dest => dest.Books,
                    opt =>
                    {
                        opt.PreCondition(src => src.IsFieldPresent(nameof(src.Books)));
                        opt.ConvertUsing<IntConverter<Book>, List<int>>();
                    });
            
            CreateMap<Author, ReadAuthorDto>();
            CreateMap<Book, AuthorBookDto>();
            CreateMap<Book, ReadAuthorBooksDto>();
        }
    }
}