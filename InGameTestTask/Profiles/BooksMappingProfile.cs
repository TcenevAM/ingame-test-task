using System.Collections.Generic;
using AutoMapper;
using InGameTestTask.Data;
using InGameTestTask.Dtos.CreateDtos;
using InGameTestTask.Dtos.PatchDtos;
using InGameTestTask.Dtos.ReadDtos;
using InGameTestTask.Models;

namespace InGameTestTask.Profiles
{
    public class BooksMappingProfile : Profile
    {
        public BooksMappingProfile()
        {
            CreateMap<PatchBookDto, Book>()
                .ForMember(dest => dest.Authors,
                    opt => opt.MapFrom(
                        (src, dest) => 
                            src.IsFieldPresent(nameof(dest.Authors)) ? src.Authors : dest.Authors))
                .ForMember(dest => dest.Edition,
                    opt => opt.MapFrom(
                        (src, dest) => 
                            src.IsFieldPresent(nameof(dest.Edition)) ? src.Edition : dest.Edition))
                .ForMember(dest => dest.Genres,
                    opt => opt.MapFrom(
                        (src, dest) => 
                            src.IsFieldPresent(nameof(dest.Genres)) ? src.Genres : dest.Genres))
                .ForMember(dest => dest.Title,
                    opt => opt.MapFrom(
                        (src, dest) => 
                            src.IsFieldPresent(nameof(dest.Title)) ? src.Title : dest.Title))
                .ForMember(dest => dest.ReleaseDate,
                    opt => opt.MapFrom(
                        (src, dest) =>
                            src.IsFieldPresent(nameof(dest.ReleaseDate)) ? src.ReleaseDate : dest.ReleaseDate));
            
            CreateMap<CreateBookDto, Book>()
                .ForMember(dest => dest.Authors,
                    opt => opt.ConvertUsing<IntConverter<Author>, List<int>>())
                .ForMember(dest => dest.Genres,
                    opt => opt.ConvertUsing<IntConverter<Genre>, List<int>>());

            CreateMap<Book, ReadBookDto>();
            CreateMap<Author, BookAuthorDto>();
        }
    }
}