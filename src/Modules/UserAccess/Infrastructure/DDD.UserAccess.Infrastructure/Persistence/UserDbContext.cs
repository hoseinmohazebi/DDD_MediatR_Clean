using DDD.UserAccess.Domain.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.UserAccess.Infrastructure.Persistence
{
    public class UserDbContext : IdentityDbContext<User>
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
