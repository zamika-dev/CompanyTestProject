using CompanyTestProject.Application.Repositories;
using CompanyTestProject.Infrustructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyTestProject.Infrustructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrustructure(this IServiceCollection services, IConfiguration configuration)
        {
            var constr = configuration.GetConnectionString("connstr");
            services.AddDbContext<CompanyTestProjectDbContext>(options => options.UseSqlServer(constr));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserProductRepository, UserProductRepository>();

            return services;
        }
    }
}
