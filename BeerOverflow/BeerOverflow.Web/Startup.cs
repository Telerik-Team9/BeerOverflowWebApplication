using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeerOverflow.Database;
using BeerOverflow.Services.Contracts;
using BeerOverflow.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BeerOverflow.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<BeerOverflowDbContext>
                (
                     options => options
                            .UseSqlServer(Configuration
                            .GetConnectionString("DefaultConnection"))
                );

            services.AddScoped<IBeerService, BeerService>();
            services.AddScoped<IBreweryService, BreweryService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IStyleService, StyleService>();
        }   

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
