using CompanyTestProject.Domain;

namespace CompanyTestProject.Application.Repositories
{
    public interface IUserProductRepository : IGenericRepository<UserProduct>
    {
        Task<List<UserProduct>> GetUserProductList(string userId);
    }
}
