using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Services;

namespace MoviesApi.Controllers
{
    [Authorize(Roles = "Admin")]
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

        [HttpPost("token")]
        public async Task<IActionResult> GetTokenAsync([FromBody]TokenRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.GetTokenAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            if(!result.MarketingConsent)
            {
                return Ok(new {Id = result.Id, accessToken = result.Token,
                    FirstName = result.FirstName, LastName = result.LastName, MarketingConsent = result.MarketingConsent, roles=result.Roles});
            }

            //return Ok(new { Id = result.Id, accessToken = result.Token, expiresOn = result.ExpiresOn });

            return Ok(result);
        }

        [HttpGet("UserById")]
        public async Task<IActionResult> GetUserByIdAsync(string Id)
        {
            TokenRequestModel model = new TokenRequestModel { Id = Id};
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.GetTokenAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            if (!result.MarketingConsent)
            {
                return Ok(new
                {
                    Id = result.Id,
                    accessToken = result.Token,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    MarketingConsent = result.MarketingConsent
                });
            }

            //return Ok(new { Id = result.Id, accessToken = result.Token, expiresOn = result.ExpiresOn });

            return Ok(result);
        }

        [HttpPost("AddRole")]
        public  async Task<ActionResult> AddRoleAsync([FromBody] AddRoleModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _authService.AddRoleAsync(model);
            if(!string.IsNullOrEmpty(result))
                return BadRequest(result);
            
            return Ok(model);
        }




    }
}
