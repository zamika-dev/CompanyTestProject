using AutoMapper;
using CompanyTestProject.Application.Repositories;
using MediatR;

namespace CompanyTestProject.Application.Features.UserProduct.Command.Create
{
    public class CreateUserProductCommandHandler : IRequestHandler<CreateUserProductCommand, int>
    {
        private readonly IUserProductRepository _UserProductRepository;
        private readonly IMapper _Mapper;

        public CreateUserProductCommandHandler(IUserProductRepository userProductRepository, IMapper mapper)
        {
            _UserProductRepository = userProductRepository;
            _Mapper = mapper;
        }

        public async Task<int> Handle(CreateUserProductCommand request, CancellationToken cancellationToken)
        {
            var userProduct = _Mapper.Map<Domain.UserProduct>(request.UserProductDto);
            userProduct = await _UserProductRepository.Add(userProduct);
            if (userProduct == null)
                throw new Exception("Product wasn't Created");

            return userProduct.Id;
        }
    }
}
