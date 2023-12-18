using AutoMapper;
using CompanyTestProject.Application.DTOs.Product;
using CompanyTestProject.Application.Features.Product.Queries.GetList;
using CompanyTestProject.Application.Profiles;
using CompanyTestProject.Application.Repositories;
using Moq;
using Shouldly;

namespace CompanyTestProject.Test
{
    public class GetProductRequestHandlerTest
    {
        IMapper _mapper;
        Mock<IProductRepository> _mockRepository;
        public GetProductRequestHandlerTest()
        {
            _mockRepository = MockProductRepository.GetProductRepository();

            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetProductListTest()
        {
            var handler = new GetProductListRequestHandler(_mockRepository.Object, _mapper);

            var result = await handler.Handle(new GetProductListRequest(), CancellationToken.None);

            result.ShouldBeOfType<List<ProductDto>>();
            result.Count.ShouldBe(2);

        }
    }
}
