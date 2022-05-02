using AutoMapper;
using DDD.UserAccess.Domain.Users;
using DDD.UserAccess.IntegrationEvents.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.UserAccess.Application.Configuration.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddUserCommand, User>()
              .ConstructUsing(t => User.CreateFromUserRegistration(t.Password, t.UserName, t.Email, t.PhoneNumber));
        }
    }
}
