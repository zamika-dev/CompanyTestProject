using CompanyTestProject.Application.DTOs;
using CompanyTestProject.Application.DTOs.Product;
using CompanyTestProject.Application.Features.Product.Commands.Create;
using CompanyTestProject.Application.Features.Product.Commands.Delete;
using CompanyTestProject.Application.Features.Product.Commands.Update;
using CompanyTestProject.Application.Features.Product.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CompanyTestProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _Mediator;

        public ProductController(IMediator mediator)
        {
            _Mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductResponseDto>>> GetAll()
        {
            var products = await _Mediator.Send(new GetProductListRequest());
            return Ok(products);
        }

        [HttpGet("/GetUserProducts")]
        public async Task<ActionResult<List<ProductResponseDto>>> GetUserProducts()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateProductRequestDto product)
        {
            var command = new CreateProductCommand { ProductRequestDto = product };
            var response = await _Mediator.Send(command);
            if (response == null)
                return Ok(response);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateProductRequestDto product)
        {
            var productDto = new UpdateProductRequestDto { ProductDto = product.ProductDto, Id = id };
            var command = new UpdateProductCommand { ProductRequestDto = productDto};
            await _Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteProductCommand { Id = id };
            await _Mediator.Send(command);
            return NoContent();
        }
    }
}
