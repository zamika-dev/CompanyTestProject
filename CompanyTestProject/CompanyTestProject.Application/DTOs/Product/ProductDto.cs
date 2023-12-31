﻿using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CompanyTestProject.Application.DTOs.Product
{
    public class ProductDto : BaseDto
    {
        public required string Name { get; set; }

        public string? ManufactureEmail { get; set; }

        public string? ManufacturePhone { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ProduceDate { get; set; }

        public bool IsAvailable { get; set; }
    }
}
