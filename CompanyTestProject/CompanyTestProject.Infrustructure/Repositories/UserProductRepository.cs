using CompanyTestProject.Application.Repositories;
using CompanyTestProject.Domain;
using Microsoft.EntityFrameworkCore;

namespace CompanyTestProject.Infrustructure.Repositories
{
    public class UserProductRepository : GenericRepository<UserProduct>, IUserProductRepository
    {
        private readonly CompanyTestProjectDbContext _Context;

        public UserProductRepository(CompanyTestProjectDbContext context) : base(context)
        {
            _Context = context;
        }

        public async Task Delete(int productId)
        {
            var userProduct = _Context.UserProduct.FirstOrDefault(c => c.ProductId == productId);
            _Context.UserProduct.Remove(userProduct);
            await _Context.SaveChangesAsync();
        }

        public async Task<List<UserProduct>> GetUserProductList(string userId)
        {
            return await _Context.UserProduct.Include(r => r.Product).Where(c => c.UserId == userId).ToListAsync();
        }
    }
}
