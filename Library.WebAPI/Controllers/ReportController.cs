using Library.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportsService;

        public ReportController(IReportService reportsService)
        {
            _reportsService = reportsService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_reportsService.GenerateReportAsync());
        }
    }
}
