using CompanyTestProject.Application.Repositories;
using MediatR;

namespace CompanyTestProject.Application.Features.Product.Commands.Delete
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IUserProductRepository _UserProductRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository, IUserProductRepository userProductRepository)
        {
            _ProductRepository = productRepository;
            _UserProductRepository = userProductRepository;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _ProductRepository.GetById(request.Id);
            if (product == null)
                throw new Exception("This product doesn't exist");

            var userProducts = await _ProductRepository.GetByUserId(request.UserId);
            if (!userProducts.Exists(x => x.Id == product.Id))
                throw new Exception("You don't have permission to delete this product");

            await _UserProductRepository.Delete(product.Id);
            await _ProductRepository.Delete(product);

            return Unit.Value;
        }
    }
}
