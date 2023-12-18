using CompanyTestProject.Domain;
using CompanyTestProject.Infrustructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CompanyTestProject.WebApi.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly CompanyTestProjectDbContext _Context;
        private readonly UserManager<User> _Usermanager;
        private readonly RoleManager<User> _RoleManager;

        public DbInitializer(CompanyTestProjectDbContext context, UserManager<User> usermanager,
            RoleManager<User> roleManager)
        {
            _Context = context;
            _Usermanager = usermanager;
            _RoleManager = roleManager;
        }
        public void Initialize()
        {
            if(_Context.Database.GetPendingMigrations().Count() > 0)
            {
                _Context.Database.Migrate();
            }
        }
    }
}
