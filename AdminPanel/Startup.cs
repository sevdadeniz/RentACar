﻿using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanel
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
            services.AddControllersWithViews();
            services.AddScoped<ICategoryService, CategoryMan>();
            services.AddScoped<ICarService, CarMan>();
            services.AddScoped<IUserService, UserMan>();
            services.AddScoped<IModelService, ModelMan>();
            services.AddScoped<IModelDAL, ModelDAL>();
            services.AddScoped<ICarDAL, CarDAL>();
            services.AddScoped<ICategoryDAL, CategoryDAL>();
            services.AddScoped<IUserDAL, UserDAL>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
            AddCookie(x =>
            {
                x.LoginPath = "/Login/LoginPanel";
            }
         );
            services.AddAuthenticationCore();
            //Bu kýsma kadar tanýmlamam
            services.AddHttpContextAccessor();
            //Role doðrulamanýn servisini ekliyoruz.
            services.AddAuthorization(options =>
            {
                options.AddPolicy("User",
                     policy => policy.RequireRole("User"));
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
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=User}/{action=Login}/{id?}");
            });
        }
    }
}
