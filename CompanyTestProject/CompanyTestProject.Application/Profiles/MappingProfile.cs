using AutoMapper;
using CompanyTestProject.Application.DTOs;
using CompanyTestProject.Application.DTOs.Product;
using CompanyTestProject.Domain;

namespace CompanyTestProject.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Product, ProductDtoResponse>().ReverseMap();
            CreateMap<Product, CreateProductRequestDto>().ReverseMap();
            CreateMap<Product, UpdateProductRequestDto>().ReverseMap();
            CreateMap<UserProduct, UserProductDto>().ReverseMap();
        }
    }
}
