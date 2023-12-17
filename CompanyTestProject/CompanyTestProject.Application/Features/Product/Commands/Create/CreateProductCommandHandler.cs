using AutoMapper;
using CompanyTestProject.Application.DTOs.Product;
using CompanyTestProject.Application.Repositories;
using CompanyTestProject.Application.Validator;
using MediatR;

namespace CompanyTestProject.Application.Features.Product.Commands.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IMapper _Mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _ProductRepository = productRepository;
            _Mapper = mapper;
        }
        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateProductDtoValidator(_ProductRepository);
            var validationResult = await validator.ValidateAsync(request.ProductRequestDto);
            if (!validationResult.IsValid)
            {
                string errorMessageList = "";
                foreach (var error in validationResult.Errors)
                    errorMessageList += "\n" + "Error: " + error.ErrorMessage;

                throw new Exception(errorMessageList);
            }

            var product = _Mapper.Map<Domain.Product>(request.ProductRequestDto);
            product = await _ProductRepository.Add(product);
            if (product == null)
                throw new Exception("Product wasn't Created");

            return product.Id;
        }
    }
}
