using CompanyTestProject.Application.DTOs.Product;
using MediatR;

namespace CompanyTestProject.Application.Features.Product.Queries.GetList
{
    public class GetProductListRequest : IRequest<List<ProductDto>>
    {
    }
}
