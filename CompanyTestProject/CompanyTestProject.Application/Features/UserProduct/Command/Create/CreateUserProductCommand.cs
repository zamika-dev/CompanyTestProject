using CompanyTestProject.Application.DTOs;
using MediatR;

namespace CompanyTestProject.Application.Features.UserProduct.Command.Create
{
    public class CreateUserProductCommand : IRequest<int>
    {
        public UserProductDto UserProductDto { get; set; } = null!;
    }
}
