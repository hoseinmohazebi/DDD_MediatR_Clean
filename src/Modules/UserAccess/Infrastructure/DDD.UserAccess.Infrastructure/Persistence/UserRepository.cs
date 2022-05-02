using DDD.Shared.Infrastructure.Persistence;
using DDD.UserAccess.Application.Contracts;
using DDD.UserAccess.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.UserAccess.Infrastructure.Persistence
{
    public class UserRepository : BaseRepository<User, UserDbContext>, IUserRepository
    {
        readonly UserManager<User> _userManager;

        public UserRepository(UserDbContext dbContext,UserManager<User> userManager) : base(dbContext)
        {
            _userManager = userManager;
        }

        public override Task Insert(User entity, bool saveChange = true)
        {
            entity.PasswordHash = _userManager.PasswordHasher.HashPassword(entity,entity.PasswordHash);
            return base.Insert(entity, saveChange);
        }
    }
}
