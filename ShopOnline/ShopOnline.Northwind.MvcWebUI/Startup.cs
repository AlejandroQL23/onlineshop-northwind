using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopOnline.Northwind.Business.Concrete;
using ShopOnline.Northwind.Business.Interfaces;
using ShopOnline.Northwind.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using ShopOnline.Northwind.DataAccess.Interfaces;
using ShopOnline.Northwind.MvcWebUI.Middlewares;

namespace ShopOnline.Northwind.MvcWebUI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductDal, EfProductRepository>();
            services.AddScoped<IProductService, ProductManager>();

            services.AddScoped<ICategoryDal, EfCategoryRepository>();
            services.AddScoped<ICategoryService, CategoryManager>();
           

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseNodeModules(env.ContentRootPath);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
