using Library.Data.Entities;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces
{
    public interface IInvertWordService
    {
        Task<Book?> GetBookWithInvertedTitle(long id);
    }
}