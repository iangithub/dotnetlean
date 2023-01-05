using CoreLib.Interface;
using CoreLib.Models;
using CoreLib.Service;
using DataEfCore.DbContextModels;
using DataEfCore.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwOnlineCourseWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<KhNetCourseContext>(
               options => options.UseSqlServer("name=ConnectionStrings:KhNetCourseDB"));
            
            services.AddControllersWithViews();

            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IStuRepository, StuRepository>();
            services.AddScoped<ICourseScheduleService, CourseScheduleService>();
            services.AddScoped<ICourseScheduleRepository, CourseScheduleRepository>();
            services.AddScoped<IShopService, ShopService>();
            services.AddScoped<IStuCourseScheduleRepository, StuCourseScheduleRepository>();
            services.AddScoped<IMemberService, MemberService>();

            //註冊 Cookie base Authentication
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                    {
                        option.LoginPath = new PathString("/Login/SignIn");
                        option.LogoutPath = new PathString("/Login/Logout");
                        //頁面停留過長，登入逾期
                        option.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                        //false不展延逾期時間,true 展延逾期時間(只要有操作系統就會展延)
                        option.SlidingExpiration = false;
                    });

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

            app.UseAuthentication(); //login 驗證
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
