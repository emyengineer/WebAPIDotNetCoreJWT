using Microsoft.AspNetCore.Mvc;
using MoviesApi.Services;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
            
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterModel model) 
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var result = await _authService.RegisterAsync(model);

            if(!result.IsAuthenticated) 
                return BadRequest(result.Message);

            return Ok(new {Id= result.Id, accessToken = result.Token, expiresOn = result.ExpiresOn});

           // return Ok(result);
        }
    }
}
