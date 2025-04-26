using AutoMapper;
using BookLibrary.Api.DTOs;
using BookLibrary.Core.Entities;

namespace BookLibrary.Api.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Book Maps
        CreateMap<Book, BookDto>();
        CreateMap<CreateBookDto, Book>();
        CreateMap<UpdateBookDto, Book>();
        
        // Author Maps
        CreateMap<Author, AuthorDto>();
        CreateMap<CreateAuthorDto, Author>();
        CreateMap<UpdateAuthorDto, Author>();
        
        // Category Maps
        CreateMap<Category, CategoryDto>();
        CreateMap<CreateCategoryDto, Category>();
        CreateMap<UpdateCategoryDto, Category>();
    }
}