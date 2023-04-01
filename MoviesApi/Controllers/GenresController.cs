using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Dtos;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GenresController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var genres = await _context.Genres.OrderBy(g => g.Name).ToListAsync();
            return Ok(genres);

        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre([FromBody]CreateGenreDto dto)
        {
            var genre = new Genre { Name = dto.Name };
            await _context.AddAsync(genre);
            _context.SaveChanges();
            return Ok(genre);
        }

    }
}
