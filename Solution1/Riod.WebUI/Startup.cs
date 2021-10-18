using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Riod.WebUI.Models.DbContexts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Riod.WebUI
{
    public class Startup
    {
        readonly IConfiguration configuration;
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRouting(cfg =>
            {
                cfg.LowercaseUrls = true;
            });
            services.AddDbContext<RiodeDbContext>(cfg =>
            {
                string ConnectinSrting = configuration.GetConnectionString("cstring");
                cfg.UseSqlServer(ConnectinSrting);
            });
        }

       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            };
            app.UseStaticFiles();
            app.UseRouting();
            
            app.UseEndpoints(cfg =>
            {
                cfg.MapGet("/coming-soon.html", async context =>
                 {
                     using (var sr= new StreamReader("views/static/coming-soon.html"))
                     {
                         context.Response.ContentType = "text/html";
                       await context.Response.WriteAsync(sr.ReadToEnd());
                     }
                 });
                cfg.MapControllerRoute("default", "{controller}/{action}/{id?}",
                    defaults: new
                    {
                        controller = "home",
                        action = "index"
                    }
                    );
            });
        }
    }
}
