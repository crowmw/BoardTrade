using AutoMapper;
using BoardTrade.Data;
using BoardTrade.Data.Interfaces;
using BoardTrade.Data.Models;
using BoardTrade.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using System.Threading.Tasks;

namespace BoardTrade
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;
        IConfigurationRoot _config;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            _env = env;
            _config = builder.Build();
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(builder =>
            {
                builder.AddConfiguration(_config.GetSection("Logging"));
                builder.AddConsole();
                builder.AddDebug();
            });

            services.AddSingleton(_config);
            services.AddDbContext<BoardTradeDbContext>(options =>
                options.UseSqlServer(_config["ConnectionStrings:DefaultConnection"])
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

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
                {
                    o.IncludeErrorDetails = true;
                    o.Audience = _config["Tokens:Audience"];
                    o.ClaimsIssuer = _config["Tokens:Issuer"];
                    o.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = _config["Tokens:Issuer"],
                        ValidAudience = _config["Tokens:Audience"],
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = signingKey,
                        ValidateLifetime = true,
                        RequireExpirationTime = true,
                        RequireSignedTokens = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ClockSkew = TimeSpan.Zero
                    };
                    o.SaveToken = true;
                })
                .AddCookie(o =>
                {
                    o.LoginPath = new Microsoft.AspNetCore.Http.PathString("/login");
                    o.LogoutPath = new Microsoft.AspNetCore.Http.PathString("/logout");

                });
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

            //Add SPA client files
            services.AddSpaStaticFiles(cfg =>
            {
                cfg.RootPath = "Client/build";
            });
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
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseMvc();

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "Client";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
 
            seeder.Seed().Wait();
            identitySeeder.Seed().Wait();
        }
    }
}
