using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyTestProject.Application.DTOs.Product
{
    public class ProductDtoBase
    {
        public required string Name { get; set; }

        public string? ManufactureEmail { get; set; }

        public string? ManufacturePhone { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ProduceDate { get; set; }

        public bool IsAvailable { get; set; }
    }
}
