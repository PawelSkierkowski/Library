using Library.Data.Models;
using Library.Domain.Interfaces;
using Library.Entities;
using System.Linq;

namespace Library.Domain.Services
{
    public class ReportService : IReportService
    {
        private readonly LibraryContext _context;

        public ReportService(LibraryContext context)
        {
            _context = context;
        }

        public IQueryable<UserSummaryView> GenerateReportAsync()
        {
            return _context.UserSummaryView.AsQueryable();
        }
    }
}
