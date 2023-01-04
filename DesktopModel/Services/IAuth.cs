using DesktopModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopModel.Services
{
    public interface IAuth
    {
        public Task<UserDetails> AuthenticateUsers(LoginModel loginModel);
    }
}
