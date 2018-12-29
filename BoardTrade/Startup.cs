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
            services.AddTransient<BoardTradeDbInitializer>();

            services.AddIdentity<BoardTradeUser, IdentityRole>()
                .AddEntityFrameworkStores<BoardTradeDbContext>();

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

            services.AddMvc()
                .AddJsonOptions(opt =>
                    {
                        opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Error;
                    }
                )
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, BoardTradeDbInitializer seeder)
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
        }
    }
}
