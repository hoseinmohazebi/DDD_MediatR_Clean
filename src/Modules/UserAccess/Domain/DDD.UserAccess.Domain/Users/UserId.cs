using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.UserAccess.Domain.Users
{
    public class UserId
    {
        public Guid Value { get; }

        public UserId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new InvalidOperationException("Id value cannot be empty!");
            }

            Value = value;
        }
    }
}
