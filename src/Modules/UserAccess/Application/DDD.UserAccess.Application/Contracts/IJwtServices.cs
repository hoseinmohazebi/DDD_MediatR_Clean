using DDD.UserAccess.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.UserAccess.Application.Contracts
{
    public interface IJwtServices
    {
        string Generate(User user);
    }
}
