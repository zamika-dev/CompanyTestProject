using CompanyTestProject.Application.DTOs.Product;
using MediatR;

namespace CompanyTestProject.Application.Features.Product.Queries.Get
{
    public class GetProductRequest : IRequest<ProductDtoResponse>
    {
        public int Id { get; set; }
    }
}
