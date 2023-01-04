using DesktopModel.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopModel.Services
{
    public class Auth : IAuth
    {
        public async Task<UserDetails> AuthenticateUsers(LoginModel loginModel)
        {
            var returnResponse = new UserDetails();
			var stream = await FileSystem.OpenAppPackageFileAsync("wwwroot/Userauth.json");
			var reader = new StreamReader(stream);
            var UserAuth = await reader.ReadToEndAsync();
            var userBasicDetail = JsonConvert.DeserializeObject<List<UserAuthDetails>>(UserAuth);
            foreach (var item in userBasicDetail)
            {
                if (item.Email == loginModel.UserName && item.Password == loginModel.Password)
                {
                    returnResponse.Name = item.Name;
                    returnResponse.Email = item.Email;
                    returnResponse.RoleId = item.RoleId;
                    break;
                }
            }
            return returnResponse;
        }
    }
}
