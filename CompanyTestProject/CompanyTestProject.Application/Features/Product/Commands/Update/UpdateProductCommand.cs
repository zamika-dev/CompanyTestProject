using CompanyTestProject.Application.DTOs.Product;
using MediatR;

namespace CompanyTestProject.Application.Features.Product.Commands.Update
{
    public class UpdateProductCommand : IRequest<Unit>
    {
        public UpdateProductRequestDto ProductRequestDto { get; set; } = null!;
        public string UserId { get; set; }
    }
}
