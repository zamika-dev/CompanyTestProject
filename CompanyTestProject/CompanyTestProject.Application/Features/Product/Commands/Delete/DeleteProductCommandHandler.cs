using AutoMapper;
using CompanyTestProject.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyTestProject.Application.Features.Product.Commands.Delete
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IProductRepository _ProductRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _ProductRepository = productRepository;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _ProductRepository.GetById(request.Id);
            if (product == null)
                throw new Exception("This product doesn't exist");

            await _ProductRepository.Delete(product);

            return Unit.Value;
        }
    }
}
