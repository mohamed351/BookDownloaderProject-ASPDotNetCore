using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookDownloader.Models;
using BookDownloader.Repositry;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookDownloader
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddNewtonsoftJson(a =>
            {
                a.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddTransient<ICategoriesRepositry, CategoryRepositry>();
            services.AddTransient<IBookRepositry, BookRepositry>();
            services.AddSwaggerDocument();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });


            services.AddDbContext<BookDownloaderContext>(a =>
            {
                a.UseSqlServer(Configuration.GetConnectionString("con"));


            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseRouting();
            app.UseNodeModules();
            app.UseStaticFiles();

            app.UseOpenApi();
            app.UseSwaggerUi3();
          
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Default",
                    "{controller}/{action}/{id?}",
                    new { controller = "Home", action = "Index" });

            });
        }
    }
}
