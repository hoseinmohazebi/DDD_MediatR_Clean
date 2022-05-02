using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.UserAccess.Domain.Users
{
    public class User : IdentityUser
    {
        private User()
        {
            // Only for EF.
        }
        private User(string hashPassword, string userName, string email, string phoneNumber)
        {
            PasswordHash = hashPassword;
            UserName = userName;
            Email = email;
            PhoneNumber = phoneNumber;
            NormalizedUserName = userName.ToUpper();
            NormalizedEmail = email.ToUpper();
            SecurityStamp = Guid.NewGuid().ToString();
            ConcurrencyStamp = Guid.NewGuid().ToString();
        }
        public static User CreateFromUserRegistration(string password, string userName, string email, string phoneNumber)
        {
            return new User(password, userName, email, phoneNumber);
        }
    }
}
