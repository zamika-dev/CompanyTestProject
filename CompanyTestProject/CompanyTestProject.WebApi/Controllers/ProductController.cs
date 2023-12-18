using CompanyTestProject.Application.DTOs;
using CompanyTestProject.Application.DTOs.Product;
using CompanyTestProject.Application.Features.Product.Commands.Create;
using CompanyTestProject.Application.Features.Product.Commands.Delete;
using CompanyTestProject.Application.Features.Product.Commands.Update;
using CompanyTestProject.Application.Features.Product.Queries.GetList;
using CompanyTestProject.Application.Features.UserProduct.Command.Create;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CompanyTestProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private string _userId { get { return User.Claims.FirstOrDefault(c => c.Type == "Guid").Value; } }

        private readonly IMediator _Mediator;

        public ProductController(IMediator mediator)
        {
            _Mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<ProductDto>>> GetAll()
        {
            var products = await _Mediator.Send(new GetProductListRequest());
            return Ok(products);
        }

        [HttpGet("GetUserProducts")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult<List<ProductDto>>> GetUserProducts()
        {
            var products = await _Mediator.Send(new GetProductListRequest() { UserId = _userId });
            return Ok(products);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> Post([FromBody] ProductDtoBase product)
        {
            var command = new CreateProductCommand { ProductDto = product };
            var productId = await _Mediator.Send(command);
            if (productId == null)
                return Ok(productId);

            var addUserProductcommand = new CreateUserProductCommand
            {
                UserProductDto = new UserProductDto
                {
                    ProductId = productId,
                    UserId = _userId
                }
            };
            var addUserProductResponse = await _Mediator.Send(addUserProductcommand);

            return Ok(addUserProductResponse);
        }

        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductDtoBase product)
        {
            var productDto = new UpdateProductRequestDto { ProductDto = product, Id = id };
            var command = new UpdateProductCommand { ProductRequestDto = productDto, UserId = _userId };
            await _Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteProductCommand { Id = id, UserId = _userId };
            await _Mediator.Send(command);
            return NoContent();
        }
    }
}
