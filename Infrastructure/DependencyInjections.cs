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
                options.ClientId = configuration["GoogleAPI:ClientId"];
                options.ClientSecret = configuration["GoogleAPI:ClientSecret"];
                options.CallbackPath = "/signin-google";
                options.SaveTokens = true;

            }).AddCookie(options => 
            {
                options.LoginPath = "/Auth/Login";
                options.AccessDeniedPath = "/Auth/AccessDenied";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.Cookie.SameSite = SameSiteMode.Lax;
            });

            services.AddHttpContextAccessor();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IAuthService,AuthService>();
            services.AddScoped<ITransactionsRepository, TransactionsRepository>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();      
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
