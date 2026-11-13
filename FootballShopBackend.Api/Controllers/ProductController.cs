using FootballShopBackend.Application.DTOs;
using FootballShopBackend.Application.Features.Products.Commands.CreateProduct;
using FootballShopBackend.Application.Features.Products.Commands.DeleteProduct;
using FootballShopBackend.Application.Features.Products.Commands.UpdateProduct;
using FootballShopBackend.Application.Features.Products.Queries.GetCoursesList;
using FootballShopBackend.Application.Features.Products.Queries.GetProductDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FootballShopBackend.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("products")]
        public async Task<ActionResult<List<ProductDTO>>> GetAllProducts()
        {
            var products = await _mediator.Send(new GetProductsListQuery());
            return Ok(products);
        }

        [HttpGet("products/{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(Guid id)
        {
            var product = await _mediator.Send(new GetProductDetailQuery(id));

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost("products")]
        public async Task<ActionResult<ProductDTO>> CreateProduct([FromBody] CreateProductCommand command)
        {
            var product = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetProductById), new { id = product }, product);
        }

        [HttpDelete("products/{id}")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            await _mediator.Send(new DeleteProductCommand(id));
           
            return NoContent();
        }

        [HttpPut("products/{id}")]
        public async Task<ActionResult<ProductDTO>> UpdateProduct(Guid id, [FromBody] UpdateProductCommand command)
        {
            if (id != command.ProductId)
            {
                return BadRequest();
            }
            await _mediator.Send(command);
            
            return NoContent();
        }
    }
}
