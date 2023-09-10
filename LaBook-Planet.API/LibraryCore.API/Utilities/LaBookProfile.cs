using AutoMapper;
using BookAPI.DTOs;
using LaBook_Planet.API.Library.Domain.Models;
using Microsoft.VisualStudio.Services.Users;

namespace Library.Core.Utilities;

public class LaBookProfile : Profile
{
    public LaBookProfile()
    {
        CreateMap<Book, AddBookDto>()
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title + " " + src.Author));
    }
}