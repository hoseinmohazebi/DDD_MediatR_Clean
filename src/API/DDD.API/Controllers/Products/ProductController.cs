using DDD.Product.IntegrationEvents.Events.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.API.Controllers.Products
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        readonly IMediator _mediatr;

        public ProductController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] GetProductListQuery query)
        {
            var res = await _mediatr.Send(query);
            return Ok(res);
        }

        [HttpPost]
        [Route("Search")]
        public async Task<IActionResult> Search(SearchProductQuery query)
        {
            var res = await _mediatr.Send(query);
            return Ok(res);
        }
    }
}
