using homecoming.api.Model;
using homecoming.api.Model.IdentityModel;
using homecoming.api.Repo.AuthRepo;
using Microsoft.AspNetCore.Mvc;

namespace homecoming.api.Controllers
{
    [ApiController]
    public class AuthController
    {
        HomecomingDbContext db;
        UserAuth UserAuth;
        public AuthController(HomecomingDbContext cx,UserAuth auth)
        {
            db = cx;
            UserAuth = auth;
        }

        [HttpPost]
        [Route("/api/[controller]/register")]
        public  string Register([FromBody] RegisterModel model)
        {
            if (UserAuth.StatusCode == 500)
            {
                return (UserAuth.Register(model));
            }
            if(UserAuth.StatusCode == 200)
            {
                return UserAuth.Register(model);
            }

            return UserAuth.Register(model);
        }
    }
}
