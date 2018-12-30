using AutoMapper;
using BoardTrade.Data;
using BoardTrade.Data.Interfaces;
using BoardTrade.Data.Models;
using BoardTrade.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace BoardTrade
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
            services.AddDbContext<BoardTradeDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddScoped<IBoardGame, BoardGameService>();
            services.AddScoped<IUser, UserService>();

            //add database initializers
            services.AddTransient<BoardTradeDbInitializer>();
            services.AddTransient<BoardTradeIdentityInitializer>();

            //add identity to project
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<BoardTradeDbContext>();

            //add cookie authentication
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(o =>
                {
                    o.LoginPath = new Microsoft.AspNetCore.Http.PathString("/login");
                    o.LogoutPath = new Microsoft.AspNetCore.Http.PathString("/logout");

                }
                );
            //.AddFacebook(o =>
            //{
            //    o.AppId = Configuration["facebook:appid"];
            //    o.AppSecret = Configuration["Facebook:appsecret"];
            //}

            services.ConfigureApplicationCookie(options =>
            {
                options.Events.OnRedirectToLogin = ctx =>
                {
                    //return 401 instead of 302
                    if (ctx.Request.Path.StartsWithSegments("/api") && ctx.Response.StatusCode == 200)
                    {
                        ctx.Response.StatusCode = 401;
                    }
                    return Task.CompletedTask;
                };

                options.Events.OnRedirectToAccessDenied = ctx =>
                {
                    //return 403 instead of 302
                    if (ctx.Request.Path.StartsWithSegments("/api") && ctx.Response.StatusCode == 200)
                    {
                        ctx.Response.StatusCode = 403;
                    }
                    return Task.CompletedTask;
                };
            });

            services.AddAutoMapper();

            services.AddMvc()
                .AddJsonOptions(opt =>
                    {
                        //Prevent cut of JSON loops in response
                        opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Error;
                    }
                )
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, BoardTradeDbInitializer seeder, BoardTradeIdentityInitializer identitySeeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
 
            seeder.Seed().Wait();
            identitySeeder.Seed().Wait();
        }
    }
}
