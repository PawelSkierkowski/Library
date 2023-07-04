using Library.Data.Models;
using Microsoft.AspNetCore.OData.Query;
using System.Linq;

namespace Library.Domain.Interfaces
{
    public interface ISearchService
    {
        IQueryable Search(ODataQueryOptions<BooksSearchView> opts);
    }
}