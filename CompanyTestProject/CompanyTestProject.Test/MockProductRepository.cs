using CompanyTestProject.Application.Repositories;
using CompanyTestProject.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyTestProject.Test
{
    public static class MockProductRepository
    {
        public static Mock<IProductRepository> GetProductRepository()
        {
            var products = new List<Product>()
        {
            new Product
            {
                Id = 1,
                Name = "Hert smart Watch",
                IsAvailable= true,
                ManufactureEmail = "ads@gmail.com",
                ManufacturePhone= "1234567890",
                ProduceDate= DateTime.Parse("2023-05-02 00:00:00.0000000")
            },
            new Product
            {
                Id = 2,
                Name = "Lois Voiton Hoodie",
                IsAvailable= true,
                ManufactureEmail = "wer@gmail.com",
                ManufacturePhone= "1234567890",
                ProduceDate= DateTime.Parse("2023-02-02 00:00:00.0000000")
            } };

            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(products);

            mockRepo.Setup(r => r.Add(It.IsAny<Product>()))
                .ReturnsAsync((Product leavetype) =>
                {
                    products.Add(leavetype);
                    return leavetype;
                });


            return mockRepo;
        }
    }
}
