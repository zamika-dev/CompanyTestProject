using AutoMapper;
using CompanyTestProject.Application.DTOs.Product;
using CompanyTestProject.Application.Repositories;
using MediatR;

namespace CompanyTestProject.Application.Features.Product.Queries.GetList
{
    public class GetProductListRequestHandler : IRequestHandler<GetProductListRequest, List<ProductDtoResponse>>
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IMapper _Mapper;

        public GetProductListRequestHandler(IProductRepository productRepository, IMapper mapper)
        {
            _ProductRepository = productRepository;
            _Mapper = mapper;
        }

        public async Task<List<ProductDtoResponse>> Handle(GetProductListRequest request, CancellationToken cancellationToken)
        {
            var productList = await _ProductRepository.GetAll();
            return _Mapper.Map<List<ProductDtoResponse>>(productList);
        }
    }
}
