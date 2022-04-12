using homecoming.api.Model.IdentityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homecoming.api.Abstraction
{
    public abstract class HandleAuth
    {
        public abstract void Register(UserRegister User);
        public void Auth(UserLogin User)
        {

        }
    }
}
