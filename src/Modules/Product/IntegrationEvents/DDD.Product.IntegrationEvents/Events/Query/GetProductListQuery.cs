using DDD.Product.IntegrationEvents.Events.Model;
using DDD.Shared.IntegrationEvents.Model;
using MediatR;

namespace DDD.Product.IntegrationEvents.Events.Query
{
    public class GetProductListQuery : Pagination, IRequest<IEnumerable<ProductDto>>
    {
    }
}