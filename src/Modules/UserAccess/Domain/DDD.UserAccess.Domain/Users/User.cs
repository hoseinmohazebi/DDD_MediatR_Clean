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
        public static List<User> Seed()
        {
            return new List<User> { new User
            {
                Id = "c0a01d1a-61b1-4bbc-b061-95e7e584c7d6",
                ConcurrencyStamp = "5e069ad4-7eb2-4f21-8e1f-87e28407fd58",
                PhoneNumber = "09111111111",
                PhoneNumberConfirmed = false,
                SecurityStamp = "93036b0e-d6b6-48b3-a049-d13edf785f0c",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "Admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                PasswordHash = "AQAAAAEAACcQAAAAECoM0y6JTi25wplleioQv+oll/qbc82t4FZ3T36J8okOykVxqPDfGX0x/zKQ/Beliw=="
            }};
        }
    }
}
