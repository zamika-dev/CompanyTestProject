﻿using CompanyTestProject.Domain;

namespace CompanyTestProject.Application.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<bool> IsManufatureEmailUniqe(string email);
        Task<bool> IsProduceDateUniqe(DateTime date);
        Task<bool> IsValidDate(DateTime date);
    }
}
