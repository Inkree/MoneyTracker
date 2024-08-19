using Application.Interfaces;
using Application.services;
using Core.interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Identity.Models;
using Infrastructure.Data.Identity.Services;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Transactions;


namespace Infrastructure
{
    public class DependencyInjections
    {
        public static void ConfigureServices(IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<MoneyTrackerDbContext>(options =>
                 options.UseSqlServer(
                     configuration.GetConnectionString("MyAppDatabase"),
                     x => x.MigrationsAssembly("Infrastructure")));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<MoneyTrackerDbContext>()
                .AddDefaultTokenProviders();
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddGoogle(options =>
            { 
                options.ClientId = "419709762966-scckv7qb9rnpdq6uh3bp60cgncminv2h.apps.googleusercontent.com";
                options.ClientSecret = "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";
                options.CallbackPath = "/signin-google";
            }).AddCookie(options => 
            {
                options.LoginPath = "/Auth/Login";
                options.AccessDeniedPath = "/Auth/AccessDenied";
            });

            services.AddHttpContextAccessor();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IAuthService,AuthService>();
            services.AddScoped<ITransactionsRepository, TransactionsRepository>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<IIconsRepository, IconsRepository>();
            
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
        public static void MigrateDatabase(IServiceProvider serviceProvider)
        {
            var dbContextOptions = serviceProvider.GetRequiredService<DbContextOptions<MoneyTrackerDbContext>>();
            var httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            using (var dbContext = new MoneyTrackerDbContext(dbContextOptions,httpContextAccessor))
            {
                dbContext.Database.Migrate();
            }
        }
    }
}
