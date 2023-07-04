using AutoMapper;
using Library.Data.Entities;
using Library.Data.Models;

namespace Library.Domain
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<BooksSearchView, Book>();
        }
    }
}

