using homecoming.api.Abstraction;
using homecoming.api.Model.IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homecoming.api.Repo.AuthRepo
{
    public class BusinessAuth:HandleAuth
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public BusinessAuth(UserManager<ApplicationUser> userM, RoleManager<IdentityRole> roleM, IConfiguration configuration) :base(userM,configuration)
        {

        }

        public override string Register(RegisterModel User)
        {
            throw new NotImplementedException();
        }
    }
}
