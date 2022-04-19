using InfCommerce.BL.Repositories;
using InfCommerce.DAL.DbContexts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfCommerce.WebUI
{
    public class Startup
    {
        IConfiguration configuration;
        public Startup(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<SqlContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("CS1")));
            //DP Life Cycle - AddSingleton - AddScoped - AddTransient

            services.AddScoped(typeof(SqlRepo<>));
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt=> { 
                
                opt.ExpireTimeSpan=TimeSpan.FromHours(5);
                opt.LoginPath = "/admin/giris";
                opt.LogoutPath = "/";
                
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            else app.UseStatusCodePagesWithReExecute("/hata/{0}");
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();    
            app.UseAuthorization(); 
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(name: "default", pattern: "{controller=home}/{action=index}/{id?}");
            });
        }
    }
}
