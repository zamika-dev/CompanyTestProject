using AutoMapper;
using CompanyTestProject.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyTestProject.Application.Features.UserProduct.Command.Delete
{
    public class DeleteUserProductCommandHandler : IRequestHandler<DeleteUserProductCommand, Unit>
    {
        private readonly IUserProductRepository _UserProductRepository;
        private readonly IMapper _Mapper;

        public DeleteUserProductCommandHandler(IUserProductRepository userProductRepository, IMapper mapper)
        {
            _UserProductRepository = userProductRepository;
            _Mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteUserProductCommand request, CancellationToken cancellationToken)
        {
            var userProduct = await _UserProductRepository.GetById(request.Id);
            if (userProduct == null)
                throw new Exception("User Product Not Found");

            await _UserProductRepository.Delete(userProduct);

            return Unit.Value;
        }
    }
}
