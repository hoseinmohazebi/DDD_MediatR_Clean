using DDD.Product.Application.Contracts;
using DDD.Product.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Product.Infrastructure
{
    public static class ProductRegistration
    {
        public static IServiceCollection AddProductServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Product"));
                options.EnableSensitiveDataLogging();
                options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
            });

            services.AddAutoMapper(typeof(Application.Contracts.IProductRepository).Assembly);
            services.AddMediatR(typeof(Application.Contracts.IProductRepository).Assembly);

            // di 
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
