using DDD.Shared.Infrastructure.Extentions;
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
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            // register fluent entity configuration
            var entitiesAssembly = typeof(UserDbContext).Assembly;

            builder.RegisterEntityTypeConfiguration(entitiesAssembly);
            base.OnModelCreating(builder);
            base.OnModelCreating(builder);
        }
    }
}
