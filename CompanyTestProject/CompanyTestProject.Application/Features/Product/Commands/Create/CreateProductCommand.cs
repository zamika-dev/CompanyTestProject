using CompanyTestProject.Application.DTOs.Product;
using MediatR;

namespace CompanyTestProject.Application.Features.Product.Commands.Create
{
    public class CreateProductCommand : IRequest<int>
    {
        public ProductDtoBase ProductDto { get; set; } = null!;
    }
}
