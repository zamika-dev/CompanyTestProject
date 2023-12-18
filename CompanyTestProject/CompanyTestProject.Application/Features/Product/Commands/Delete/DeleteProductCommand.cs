using MediatR;

namespace CompanyTestProject.Application.Features.Product.Commands.Delete
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
    }
}
