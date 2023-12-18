using AutoMapper;
using CompanyTestProject.Application.DTOs.Product;
using CompanyTestProject.Application.Repositories;
using MediatR;

namespace CompanyTestProject.Application.Features.Product.Queries.GetList
{
    public class GetProductListRequestHandler : IRequestHandler<GetProductListRequest, List<ProductDto>>
    {
        private readonly IProductRepository _ProductRepository;
        private readonly IMapper _Mapper;

        public GetProductListRequestHandler(IProductRepository productRepository, IMapper mapper)
        {
            _ProductRepository = productRepository;
            _Mapper = mapper;
        }

        public async Task<List<ProductDto>> Handle(GetProductListRequest request, CancellationToken cancellationToken)
        {
            if (request.UserId != null)
            {
                var productList = await _ProductRepository.GetByUserId(request.UserId);
                return _Mapper.Map<List<ProductDto>>(productList);
            }
            else
            {
                var productList = await _ProductRepository.GetAll();
                return _Mapper.Map<List<ProductDto>>(productList);
            }
        }
    }
}
