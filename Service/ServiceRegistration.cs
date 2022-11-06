using Application.Repositories;
using Application.Service;
using Microsoft.Extensions.DependencyInjection;
using Service.Concreate;
using Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class ServiceRegistration
    {
       public static void AddPersistenceService(this IServiceCollection services)
        {
            services.AddScoped<IProductService,ProductService>();
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<IUserService,UserService>();

        }
        /*
         Services.AddDbContext<MvcAppContext>(b =>
b.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddIdentity<AppUser,IdentityRole>().AddEntityFrameworkStores<MvcAppContext>();
         */
    }
}
