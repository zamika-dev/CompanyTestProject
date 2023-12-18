using CompanyTestProject.Application.DTOs.Product;
using MediatR;

namespace CompanyTestProject.Application.Features.Product.Queries.Get
{
    public class GetProductRequest : IRequest<ProductResponseDto>
    {
        public int Id { get; set; }
    }
}
