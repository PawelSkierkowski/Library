using AutoMapper;
using Library.Data.Models;
using Library.Domain.Interfaces;
using Library.Entities;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Query.Validator;
using System.Linq;

namespace Library.Domain.Services
{
    public class SearchService : ISearchService
    {
        private readonly LibraryContext _context;
        private readonly ODataValidationSettings _settings;
        public readonly IMapper _mapper;

        public SearchService(LibraryContext context, ODataValidationSettings settings, IMapper mapper)
        {
            _context = context;
            _settings = settings;
            _mapper = mapper;
        }

        public IQueryable Search(ODataQueryOptions<BooksSearchView> opts)
        {
            opts.Validate(_settings);
            var result = opts.ApplyTo(_context.BooksSearchView.AsQueryable());
            return result;
        }
    }
}
