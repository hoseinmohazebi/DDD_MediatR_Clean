using DDD.UserAccess.IntegrationEvents.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.UserAccess.IntegrationEvents.Events
{
    public class LoginUserQuery : IRequest<LoginDto>
    {
        public LoginUserQuery(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
