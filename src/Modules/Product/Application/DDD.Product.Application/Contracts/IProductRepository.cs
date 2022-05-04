using DDD.Shared.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Product.Application.Contracts
{
    public interface IProductRepository : IBaseRepository<DDD.Product.Domain.Product.Product>
    {
    }
}
