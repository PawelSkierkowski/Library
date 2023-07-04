using Library.Data.Entities;
using Library.Domain.Interfaces;
using Library.Entities;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library.Domain.Services
{
    public class InvertWordService : IInvertWordService
    {
        private readonly LibraryContext _context;

        public InvertWordService(LibraryContext context)
        {
            _context = context;
        }

        public async Task<Book?> GetBookWithInvertedTitle(long id)
        {
            var foundBook = await _context.Books.FindAsync(id);
            if (foundBook != null)
            {
                foundBook.Title = string.Concat(Regex.Split(foundBook.Title, @"([^\w]+)").Reverse());
                return foundBook;
            }

            return null;
        }
    }
}
