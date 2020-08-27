using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace ShopOnline.Northwind.MvcWebUI.Middlewares
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseNodeModules(this IApplicationBuilder applicationBuilder, string root)
        {
            var path = Path.Combine(root, "node_modules");
            var provider = new PhysicalFileProvider(path);

            var options = new StaticFileOptions
            {
                RequestPath = "/node_modules",
                FileProvider = provider
            };

            applicationBuilder.UseStaticFiles(options);

            return applicationBuilder;
        }
    }
}
