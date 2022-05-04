using AutoMapper;
using DDD.Product.IntegrationEvents.Events.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Product.Application.Configuration.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product.Domain.Product.Product, ProductDto>();
        }
    }
}
