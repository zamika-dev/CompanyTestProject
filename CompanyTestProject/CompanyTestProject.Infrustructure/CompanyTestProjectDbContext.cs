using CompanyTestProject.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CompanyTestProject.Infrustructure
{
    public class CompanyTestProjectDbContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<UserProduct> UserProduct { get; set; }

        public CompanyTestProjectDbContext(DbContextOptions<CompanyTestProjectDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CompanyTestProjectDbContext).Assembly);
        }
    }
}
