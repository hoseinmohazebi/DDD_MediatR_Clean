using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.UserAccess.Infrastructure.Persistence
{
    public static class ApplyPendingMigration
    {
        public static void ApplyUserAccessMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                serviceScope?.ServiceProvider?.GetService<UserDbContext>()?.Database.Migrate(); 
            }
        }
    }
}
