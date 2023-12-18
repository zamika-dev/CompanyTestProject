using AutoMapper;
using CompanyTestProject.Application.DTOs;
using CompanyTestProject.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyTestProject.Application.Features.UserProduct.Queries.GetList
{
    public class GetUserProductListRequestHandler : IRequestHandler<GetUserProductListRequest, List<UserProductDto>>
    {
        private readonly IUserProductRepository _UserProductRepository;
        private readonly IMapper _Mapper;

        public GetUserProductListRequestHandler(IUserProductRepository userProductRepository, IMapper mapper)
        {
            _UserProductRepository = userProductRepository;
            _Mapper = mapper;
        }

        public async Task<List<UserProductDto>> Handle(GetUserProductListRequest request, CancellationToken cancellationToken)
        {
            var userProductList = await _UserProductRepository.GetUserProductList(request.UserId);
            if (userProductList == null)
                throw new Exception("");

            return _Mapper.Map<List<UserProductDto>>(userProductList);
        }
    }
}
