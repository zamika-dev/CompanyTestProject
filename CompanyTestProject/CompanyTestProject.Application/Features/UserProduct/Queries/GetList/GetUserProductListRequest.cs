using CompanyTestProject.Application.DTOs;
using MediatR;

namespace CompanyTestProject.Application.Features.UserProduct.Queries.GetList
{
    public class GetUserProductListRequest : IRequest<List<UserProductDto>>
    {
        public string UserId { get; set; } = null!;
    }
}
