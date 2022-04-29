using homecoming.api.Abstraction;
using homecoming.api.Model.IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;


namespace homecoming.api.Repo.AuthRepo
{
    public class AdminAuth: HandleAuth
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public AdminAuth(UserManager<ApplicationUser> userM, RoleManager<IdentityRole> roleM, IConfiguration configuration) : base(userM,configuration)
        {

        }

        public override string Register(RegisterModel User)
        {
            throw new NotImplementedException();
        }
    }
}
