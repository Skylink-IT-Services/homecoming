using homecoming.api.Model.IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace homecoming.api.Abstraction
{
    public abstract class HandleAuth
    {
        protected readonly UserManager<ApplicationUser> userManager;
        protected readonly IConfiguration _configuration;
        public HandleAuth(UserManager<ApplicationUser> userM, IConfiguration configuration)
        {
            userManager = userM;
            _configuration = configuration;
        }
        public bool isRegistered { get; set; } = false;
        public bool isLogged { get; set; } = false;
        public TokenResponse Token { get; set; }
        public abstract string Register(RegisterModel User);
        public async Task AuthAsync(LoginModel User)
        {
            var user =await userManager.FindByNameAsync(User.Username);
            if (user != null &&  await userManager.CheckPasswordAsync(user, User.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                Token = new TokenResponse() 
                { 
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
                };
                isLogged = true;
            }
            isLogged = false;
        }
    }
}
