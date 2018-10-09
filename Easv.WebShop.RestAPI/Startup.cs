using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Easv.WebShop.Core.ApplicationService.IServices;
using Easv.WebShop.Core.ApplicationService.Services;
using Easv.WebShop.Core.DomainService;
using Easv.WebShop.Infrastructure.Data;
using Easv.WebShop.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Easv.WebShop.RestAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
            
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors();

            if (Environment.IsDevelopment())
            {
                services.AddDbContext<WebShopContext>(
                    opt => opt.UseSqlite("Data Source=WebShopApp.db"));
            }
            else if (Environment.IsProduction())
            {
                services.AddDbContext<WebShopContext>(
                    opt => opt.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));
            }

            services.AddScoped<IWhiskeyService, WhiskeyService>();
            services.AddScoped<IWhiskeyRepository, WhiskeyRepository>();

            services.AddScoped<IWhiskeyTypeService, WhiskeyTypeService>();
            services.AddScoped<IWhiskeyTypeRepository, WhiskeyTypeRepository>();

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling 
                    = ReferenceLoopHandling.Ignore;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<WebShopContext>();
                    DBInitializer.SeedDB(ctx);
                }
            }
            else
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<WebShopContext>();
                    ctx.Database.EnsureCreated();
                }

                app.UseHsts();
            }

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod());


            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }

}
