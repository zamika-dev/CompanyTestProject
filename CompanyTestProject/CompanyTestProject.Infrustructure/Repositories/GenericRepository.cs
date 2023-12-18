using CompanyTestProject.Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CompanyTestProject.Infrustructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly CompanyTestProjectDbContext _Context;

        public GenericRepository(CompanyTestProjectDbContext context)
        {
            _Context = context;
        }

        public async Task<T> Add(T entity)
        {
            await _Context.AddAsync(entity);
            await _Context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(T entity)
        {
            _Context.Set<T>().Remove(entity);
            await _Context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _Context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _Context.Set<T>().FindAsync(id);
        }

        public async Task Update(T entity)
        {
            _Context.Entry(entity).State = EntityState.Modified;
            await _Context.SaveChangesAsync();
        }
    }
}
