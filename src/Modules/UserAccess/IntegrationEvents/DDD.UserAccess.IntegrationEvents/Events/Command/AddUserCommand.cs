using DDD.UserAccess.IntegrationEvents.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.UserAccess.IntegrationEvents.Events.Command
{
    public class AddUserCommand : IRequest<LoginDto>
    {
        public AddUserCommand(string password, string userName, string email, string phoneNumber)
        {
            Password = password;
            UserName = userName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public string Password { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
