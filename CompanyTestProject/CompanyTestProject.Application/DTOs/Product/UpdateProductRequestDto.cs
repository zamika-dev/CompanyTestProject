using CompanyTestProject.Application.DTOs;

namespace CompanyTestProject.Application.DTOs.Product
{
    public class UpdateProductRequestDto : BaseDto
    {
        public ProductDtoBase ProductDto { get; set; }
    }
}
