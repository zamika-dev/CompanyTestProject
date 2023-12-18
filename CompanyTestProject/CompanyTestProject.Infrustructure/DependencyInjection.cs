using CompanyTestProject.Application.Models;
using CompanyTestProject.Application.Repositories;
using CompanyTestProject.Infrustructure.Authentication;
using CompanyTestProject.Infrustructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CompanyTestProject.Infrustructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrustructure(this IServiceCollection services, IConfiguration configuration)
        {
            var constr = configuration.GetConnectionString("connstr");
            services.AddDbContext<CompanyTestProjectDbContext>(options => options.UseSqlServer(constr));
            services.AddIdentity<Domain.User, IdentityRole>(c =>
            {
                c.Password.RequiredLength = 4;
                c.Password.RequiredUniqueChars = 2;
                c.Password.RequireNonAlphanumeric = false;
                c.Password.RequireUppercase = false;
                c.Password.RequireDigit = false;
                c.User.RequireUniqueEmail = true;
                c.User.AllowedUserNameCharacters = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
            }).AddEntityFrameworkStores<CompanyTestProjectDbContext>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserProductRepository, UserProductRepository>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            //Jwt and Identity Settings
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                };
            });

            return services;
        }
    }
}
