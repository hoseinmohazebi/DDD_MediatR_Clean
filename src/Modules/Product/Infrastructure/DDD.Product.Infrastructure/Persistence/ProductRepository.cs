using DDD.Product.Application.Contracts;
using DDD.Shared.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Product.Infrastructure.Persistence
{
    public class ProductRepository : BaseRepository<DDD.Product.Domain.Product.Product, ProductDbContext>, IProductRepository
    {
        public ProductRepository(ProductDbContext dbContext) : base(dbContext)
        {
        }
    }
}
