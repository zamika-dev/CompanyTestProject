using System.ComponentModel.DataAnnotations;

namespace CompanyTestProject.Application.DTOs.Product
{
    public class ProductDto
    {
        public required string Name { get; set; }

        public string? ManufactureEmail { get; set; }

        public string? ManufacturePhone { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ProduceDate { get; set; }

        public bool IsAvailable { get; set; }
    }
}
