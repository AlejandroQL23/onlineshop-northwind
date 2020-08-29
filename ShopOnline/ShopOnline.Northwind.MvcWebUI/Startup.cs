using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopOnline.Core.Settings;
using ShopOnline.Northwind.Business.Concrete;
using ShopOnline.Northwind.Business.Interfaces;
using ShopOnline.Northwind.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using ShopOnline.Northwind.DataAccess.Interfaces;
using ShopOnline.Northwind.MvcWebUI.Entities;
using ShopOnline.Northwind.MvcWebUI.Middlewares;
using ShopOnline.Northwind.MvcWebUI.Services;

namespace ShopOnline.Northwind.MvcWebUI
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();
            services.AddHttpContextAccessor();

            services.Configure<ProductControllerSettings>(Configuration.GetSection(nameof(ProductControllerSettings)));

            services.AddDbContext<CustomIdentityDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"));
            });

            services.AddIdentity<CustomIdentityUser, CustomIdentityRole>()
                    .AddEntityFrameworkStores<CustomIdentityDbContext>()
                    .AddDefaultTokenProviders();

            services.AddScoped<IProductDal, EfProductRepository>();
            services.AddScoped<IProductService, ProductManager>();

            services.AddScoped<ICategoryDal, EfCategoryRepository>();
            services.AddScoped<ICategoryService, CategoryManager>();

            services.AddSingleton<ICartSessionService, CartSessionManager>();
            services.AddSingleton<ICartService, CartManager>();

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

            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute
                (
                    name: "areas",
                    pattern: "{area}/{controller=Account}/{action=SignIn}/{id?}"
                );

                endpoints.MapControllerRoute
                (
                    name: "default",
                    pattern: "{controller=Product}/{action=Index}/{id?}"
                );
            });
        }
    }
}
