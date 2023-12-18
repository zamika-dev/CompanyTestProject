using AutoMapper;
using CompanyTestProject.Application.Repositories;
using CompanyTestProject.Application.Validator;
using MediatR;

namespace CompanyTestProject.Application.Features.Product.Commands.Update
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IMapper _Mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _ProductRepository = productRepository;
            _Mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateProductDtoValidator(_ProductRepository);
            var validationResult = await validator.ValidateAsync(request.ProductRequestDto);
            if (!validationResult.IsValid)
            {
                string errorMessageList = "";
                foreach (var error in validationResult.Errors)
                    errorMessageList += "\n" + "Error: " + error.ErrorMessage;

                throw new Exception(errorMessageList);
            }

            var product = await _ProductRepository.GetById(request.ProductRequestDto.Id);
            if (product == null)
                throw new Exception("Product Not exist");

            var userProducts = await _ProductRepository.GetByUserId(request.UserId);
            if (!userProducts.Exists(x => x.Id == product.Id))
                throw new Exception("You don't have permission to edit this product");

            _Mapper.Map(request.ProductRequestDto.ProductDto, product);
            await _ProductRepository.Update(product);

            return Unit.Value;
        }
    }
}
