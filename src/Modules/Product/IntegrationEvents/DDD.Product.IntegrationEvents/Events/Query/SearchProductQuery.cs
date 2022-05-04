using DDD.Product.IntegrationEvents.Events.Model;
using DDD.Shared.IntegrationEvents.Model;
using MediatR;
using static DDD.Product.Domain.Product.ProductEnum;

namespace DDD.Product.IntegrationEvents.Events.Query
{
    public class SearchProductQuery : Pagination, IRequest<IEnumerable<ProductDto>>
    {
        public ProductColor? Color { get; set; }
        public ProductType? Type { get; set; }
    }
}