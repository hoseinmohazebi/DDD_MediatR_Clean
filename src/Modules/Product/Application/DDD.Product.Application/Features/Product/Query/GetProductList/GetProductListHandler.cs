using AutoMapper;
using DDD.Product.Application.Contracts;
using DDD.Product.IntegrationEvents.Events.Model;
using DDD.Product.IntegrationEvents.Events.Query;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Product.Application.Features.Product.Query.GetProductList
{
    public class GetProductListHandler : IRequestHandler<GetProductListQuery, IEnumerable<ProductDto>>
    {
        readonly IProductRepository _productRepo;
        readonly IMapper _mapper;

        public GetProductListHandler(IProductRepository productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            var res = await _productRepo.GetPagination(request.Skip(), request.Size);
            return _mapper.Map<List<ProductDto>>(res);
        }
    }
}
