using Library.Data.Models;
using System.Linq;

namespace Library.Domain.Interfaces
{
    public interface IReportService
    {
        IQueryable<UserSummaryView> GenerateReportAsync();
    }
}