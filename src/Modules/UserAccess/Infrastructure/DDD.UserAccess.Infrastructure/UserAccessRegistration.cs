using DDD.UserAccess.Application.Contracts;
using DDD.UserAccess.Application.Models.Jwt;
using DDD.UserAccess.Infrastructure.Identity;
using DDD.UserAccess.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DDD.UserAccess.Infrastructure
{
    public static class UserAccessRegistration
    {
        public static IServiceCollection AddUserAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<Domain.Users.User, IdentityRole>()
                    .AddEntityFrameworkStores<UserDbContext>()
                    .AddDefaultTokenProviders();

            services.AddDbContext<UserDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("UserAccess"));
                options.EnableSensitiveDataLogging();
                options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
            });

            services.AddAutoMapper(typeof(Application.Features.User.Commands.AddUser.AddUserCommandHandler).Assembly);
            services.AddMediatR(typeof(Application.Features.User.Commands.AddUser.AddUserCommandHandler).Assembly);

            // jwt & swagger
            services.AddJwt_Swagger(configuration);

            // di
            services.AddScoped<IJwtServices, JwtService>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
