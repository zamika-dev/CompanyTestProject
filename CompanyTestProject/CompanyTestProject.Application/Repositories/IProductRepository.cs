using CompanyTestProject.Domain;

namespace CompanyTestProject.Application.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<List<Product>> GetByUserId(string userId);
        Task<bool> IsManufatureEmailUniqe(string email);
        Task<bool> IsProduceDateUniqe(DateTime date);
        Task<bool> IsValidDate(DateTime date);

        Task<bool> Update_IsManufatureEmailUniqe(string email, int productId);
        Task<bool> Update_IsProduceDateUniqe(DateTime date, int productId);
    }
}
