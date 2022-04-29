using homecoming.api.Abstraction;
using homecoming.api.Model.IdentityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;


namespace homecoming.api.Repo.AuthRepo
{
    public class UserAuth : HandleAuth
    {
        public int StatusCode { get; set; }
        public string Response { get; set; }
        public UserAuth(UserManager<ApplicationUser> userM, IConfiguration configuration) : base(userM,configuration)
        {
        }
        public override string Register(RegisterModel User)
        {
            var userExists =  userManager.FindByNameAsync(User.Email);
            if (userExists != null)
            {
                StatusCode = StatusCodes.Status500InternalServerError;
                isRegistered = false;
                return new Response { Status = "Error", Message = "User already exists!" }.ToString();
            }

            ApplicationUser user = new ApplicationUser()
            {
                Email = User.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = User.Email
            };
            var result =  userManager.CreateAsync(user, User.Password);
            if (!result.IsCompletedSuccessfully)
            {
                StatusCode = StatusCodes.Status500InternalServerError;
                isRegistered = false;
                return new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." }.ToString();
            }

            isRegistered = true;
            StatusCode = StatusCodes.Status200OK;
            return new Response { Status = "Success", Message = "User created successfully!" }.ToString();
        }
        
    }
}
