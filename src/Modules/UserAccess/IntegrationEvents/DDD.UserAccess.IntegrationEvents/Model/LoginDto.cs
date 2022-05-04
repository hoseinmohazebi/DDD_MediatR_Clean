using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.UserAccess.IntegrationEvents.Model
{
    public class LoginDto
    {
        public string Token { get; set; }
        public string UserName { get; set; }

        public LoginDto(string token, string userName)
        {
            Token = token;
            UserName = userName;
        }
    }
}
