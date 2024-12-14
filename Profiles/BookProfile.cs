using AutoMapper;
using LibraryManagementSystem.Dtos;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Profiles
{
    public class BookProfile : Profile
    {

        public BookProfile()
        {
            CreateMap<BookCreateDto, Book>();
            CreateMap<Book, BookReadDto>();
        }
    }
}
