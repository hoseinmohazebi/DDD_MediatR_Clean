using DDD.UserAccess.IntegrationEvents.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.UserAccess.IntegrationEvents.Events.Query
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
