using Library.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvertWordsController : ControllerBase
    {
        private readonly IInvertWordService _invertWordService;

        public InvertWordsController(IInvertWordService invertWordService)
        {
            _invertWordService = invertWordService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            var result = await _invertWordService.GetBookWithInvertedTitle(id);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}
