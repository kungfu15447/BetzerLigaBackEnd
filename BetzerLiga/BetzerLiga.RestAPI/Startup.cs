﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetzerLiga.Core.ApplicationService;
using BetzerLiga.Core.ApplicationService.Implementation;
using BetzerLiga.Core.DomainService;
using BetzerLiga.Infrastructure.SQL;
using BetzerLiga.Infrastructure.SQL.Repositories;
using BetzerLiga.RestAPI.Initializer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace BetzerLiga.RestAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IRoundRepository, RoundRepository>();
            services.AddScoped<IRoundService, RoundService>();

            Byte[] secretBytes = new byte[40];
            Random rand = new Random();
            rand.NextBytes(secretBytes);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretBytes),
                    ValidateLifetime = true, //validate the expiration and not before values in the token
                    ClockSkew = TimeSpan.FromMinutes(5) //2 minute tolerance for the expiration date
                };
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IMatchRepository, MatchRepository>();
            services.AddScoped<IMatchService, MatchService>();

            services.AddScoped<ITourRepository, TourRepository>();
            services.AddScoped<ITourService, TourService>();

            services.AddScoped<IUserMatchRepository, UserMatchRepository>();
            services.AddScoped<IUserMatchService, UserMatchService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            //CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin",
                    builder => builder
                        .AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            //Database setup

            services.AddTransient<IDBInitializer, DBInitializer>();

            services.AddSingleton<IAuthenticationHelper>(new AuthenticationHelper(secretBytes));

            // Register database initializer
             if (Environment.IsDevelopment())
             {
                 services.AddDbContext<BetzerLigaContext>(
                 optionsAction: opt => opt.UseSqlite(
                     connectionString: "Data Source = BetzerLiga.db"));
             }
             else
             {
                 services.AddDbContext<BetzerLigaContext>(opt =>
                 opt.UseSqlServer(Configuration.GetConnectionString
                 ("defaultConnection")));
             }

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.MaxDepth = 10;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("AllowAnyOrigin");

            if (env.IsDevelopment())
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var context = services
                        .GetRequiredService<BetzerLigaContext>();
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    var dbInitializer = services.GetRequiredService<IDBInitializer>();
                    dbInitializer.Seed(context);
                }
                app.UseDeveloperExceptionPage();
            }
            else
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var context = scope.ServiceProvider
                        .GetRequiredService<BetzerLigaContext>();
                    context.Database.EnsureCreated();

                }
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
