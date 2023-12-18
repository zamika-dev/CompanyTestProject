using CompanyTestProject.Infrustructure;
using Microsoft.EntityFrameworkCore;

namespace CompanyTestProject.WebApi
{
    public static class MigrateDb
    {
        public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder builder)
        {
            using (var scope = builder.ApplicationServices.CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<CompanyTestProjectDbContext>())
                {
                    context.Database.Migrate();
                }
            }
            return builder;
        }
    }
}
