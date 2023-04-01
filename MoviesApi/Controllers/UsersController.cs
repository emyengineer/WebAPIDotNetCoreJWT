using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: api/<UsersController>
        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            var genres = await _context.Users.ToListAsync();
            return Ok(genres);

        }

        
        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO dto)
        {
            // Create Id from SHA1 of the Email Address, salted with “450d0b0db2bcf4adde5032eca1a7c416e560cf44” string 


            var user = new User
            {
                Id = dto.HashPasword(dto.Email),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                MarketingConsent = dto.MarketingConsent,
            };
            await _context.Users.AddAsync(user); // or  _context.AddAsync(user);
            _context.SaveChanges();
            return Ok(user.Id);

        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
