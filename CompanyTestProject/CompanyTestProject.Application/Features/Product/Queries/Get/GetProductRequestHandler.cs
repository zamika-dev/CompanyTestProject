using AutoMapper;
using CompanyTestProject.Application.DTOs.Product;
using CompanyTestProject.Application.Repositories;
using MediatR;

namespace CompanyTestProject.Application.Features.Product.Queries.Get
{
    public class GetProductRequestHandler : IRequestHandler<GetProductRequest, ProductResponseDto>
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IMapper _Mapper;

        public GetProductRequestHandler(IProductRepository productRepository, IMapper mapper)
        {
            _ProductRepository = productRepository;
            _Mapper = mapper;
        }

        public async Task<ProductResponseDto> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _ProductRepository.GetById(request.Id);
            if (product == null)
                throw new Exception("Product does not exist");

            return _Mapper.Map<ProductResponseDto>(product);
        }
    }
}
