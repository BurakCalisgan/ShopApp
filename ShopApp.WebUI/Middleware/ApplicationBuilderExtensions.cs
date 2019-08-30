using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.Middleware
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder CustomStaticFiles(this IApplicationBuilder app)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "node_modules");

            var options = new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(path),
                RequestPath="/modules" //yol olarak artık dosyalarım bu aliaslı klasörde olacak. normalde node_modulesti biz onu bu şekilde değiştirdik.
            };
            app.UseStaticFiles(options);
            return app;
        }
    }
}
