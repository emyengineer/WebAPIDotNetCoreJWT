using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MoviesApi.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MoviesApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;

        private readonly JWT _jwt;

        public AuthService(UserManager<User>  userManager, IOptions<JWT> jwt)
        {
            _userManager = userManager;
            _jwt = jwt.Value;
        }

        public async Task<AuthModel> RegisterAsync(RegisterModel model)
        {
            if(await _userManager.FindByEmailAsync(model.Email) is not null)
            {
                return new AuthModel { Message = "Email is already registered" };
            }
            if (await _userManager.FindByNameAsync(model.UserName) is not null)
            {
                return new AuthModel { Message = "UserName is already registered" };
            }

            var user = new User
            {
                Id = model.HashPasword(model.Email),
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                var errors = string.Empty;

                foreach(var error in result.Errors)
                {
                    errors += $"{error.Description},"; 
                }

                return new AuthModel { Message = errors };

            }

            // Add Role to User
            await _userManager.AddToRoleAsync(user, "User");

            var jwtToken = await CreateJwtSecurityToken(user);

            return new AuthModel
            {
                
                Id = user.Id,
                Email = user.Email,
                ExpiresOn = jwtToken.ValidTo,
                IsAuthenticated = true,
                Roles = new List<string> { "User" },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                UserName = user.UserName
            };
        }

        private async Task<JwtSecurityToken> CreateJwtSecurityToken(User user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles) {
                roleClaims.Add(new Claim("roles", role));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}
