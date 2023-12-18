using CompanyTestProject.Application.DTOs.Product;
using MediatR;

namespace CompanyTestProject.Application.Features.Product.Queries.GetList
{
    public class GetProductListRequest : IRequest<List<ProductDto>>
    {
        public string UserId { get; set; } = null!;
    }
}
