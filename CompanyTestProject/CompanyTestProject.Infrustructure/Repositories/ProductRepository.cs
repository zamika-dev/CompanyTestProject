using CompanyTestProject.Application.Repositories;
using CompanyTestProject.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyTestProject.Infrustructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly CompanyTestProjectDbContext _Context;

        public ProductRepository(CompanyTestProjectDbContext context) : base(context)
        {
            _Context = context;
        }

        public async Task<List<Product>> GetByUserId(string userId)
        {
            return await(from p in _Context.Products
                         join u in _Context.UserProduct on p.Id equals u.ProductId
                         where u.UserId == userId
                         select p).ToListAsync();
        }

        public async Task<bool> IsManufatureEmailUniqe(string email)
        {
            var result = await _Context.Products.AnyAsync(c => c.ManufactureEmail == email);
            return !result;
        }

        public async Task<bool> IsProduceDateUniqe(DateTime date)
        {
            var result = await _Context.Products.AnyAsync(c => c.ProduceDate == date);
            return !result;
        }

        public async Task<bool> IsValidDate(DateTime date)
        {
            return DateTime.TryParse(date.ToString(), out var temp);
        }

        public async Task<bool> Update_IsManufatureEmailUniqe(string email, int productId)
        {
            var result = await _Context.Products.AnyAsync(c => c.ManufactureEmail == email && c.Id != productId);
            return !result;
        }

        public async Task<bool> Update_IsProduceDateUniqe(DateTime date, int productId)
        {
            var result = await _Context.Products.AnyAsync(c => c.ProduceDate == date && c.Id != productId);
            return !result;
        }
    }
}
