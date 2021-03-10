using IS_413_Assignment_5.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IS_413_Assignment_5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //passing in the configuration for accessing the database
            services.AddDbContext<BookstoreDbContext>(options=>
           {
               options.UseSqlite(Configuration["ConnectionStrings:BookstoreConnection"]);
           });

            services.AddScoped<IBookstoreRepository, EFBookstoreRepository>();

            //add the services for razor pages
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //user can type in the destination but also is generating outgoing urls we can use for ourselves! consistency on the ways to get to the right place. Order Matters!

                endpoints.MapControllerRoute("categorypage",
                    "{category}/{page:int}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("page",
                    "{page:int}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("category",
                   "{category}",
                   new { Controller = "Home", action = "Index", page = 1 });

                endpoints.MapControllerRoute("pagination",
                    "Books/P{page}",
                    new { Controller = "Home", action = "Index" });



                endpoints.MapDefaultControllerRoute();

                //add another endpoiont for razor pages
                endpoints.MapRazorPages();

                    /* name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}")*/
            });

            SeedData.EnsurePopulated(app);
        }
    }
}
