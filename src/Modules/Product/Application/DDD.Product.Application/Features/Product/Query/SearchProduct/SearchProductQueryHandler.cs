using AutoMapper;
using DDD.Product.Application.Contracts;
using DDD.Product.Domain.Product;
using DDD.Product.IntegrationEvents.Events.Model;
using DDD.Product.IntegrationEvents.Events.Query;
using MediatR;
using System.Linq.Expressions;

namespace DDD.Product.Application.Features.Product.Query.SearchProduct
{
    public class SearchProductQueryHandler : IRequestHandler<SearchProductQuery, IEnumerable<ProductDto>>
    {
        readonly IProductRepository _productRepo;
        readonly IMapper _mapper;

        public SearchProductQueryHandler(IProductRepository productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> Handle(SearchProductQuery request, CancellationToken cancellationToken)
        {
            var res = await _productRepo.GetPagination(request.Skip(), request.Size, t => (request.Color != null ? t.Color == request.Color : true) &&
                                                                                                  (request.Type != null ? t.Type == request.Type : true));
            return _mapper.Map<List<ProductDto>>(res);
        }
    }
}
