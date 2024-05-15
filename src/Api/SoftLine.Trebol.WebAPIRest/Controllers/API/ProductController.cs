using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftLine.Trebol.Application.Features.Products.Queries.GetProductById;
using SoftLine.Trebol.Application.Features.Products.Queries.GetProductList;
using SoftLine.Trebol.Application.Features.Products.Queries.PaginationProducts;
using SoftLine.Trebol.Application.Features.Products.Queries.Vms;
using SoftLine.Trebol.Application.Features.Shared.Queries;
using SoftLine.Trebol.Domain;
using System.Net;

namespace SoftLine.Trebol.WebAPIRest.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpGet("list", Name = "GetProductList")]
        [ProducesResponseType(typeof(IReadOnlyList<ProductVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IReadOnlyList<ProductVm>>> GetProductList()
        {
            var query = new GetProductListQuery();
            var productos = await _mediator.Send(query);
            return Ok(productos);
        }

        [AllowAnonymous]
        [HttpGet("pagination", Name = "PaginationProduct")]
        [ProducesResponseType(typeof(PaginationVm<ProductVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<PaginationVm<ProductVm>>> PaginationProduct([FromQuery] PaginationProductsQuery paginationProductParams)
        {
            paginationProductParams.Status = ProductStatus.Activo;
            var paginationProduct = await _mediator.Send(paginationProductParams);

            return Ok(paginationProduct);
        }

        [AllowAnonymous]
        [HttpGet("{id}", Name = "GetProductById")]
        [ProducesResponseType(typeof(ProductVm), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ProductVm>> GetProductById(int id)
        {
            var query = new GetProductByIdQuery(id);
            return Ok(await _mediator.Send(query));
        }
    }
}
