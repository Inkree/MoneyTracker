using Application.Interfaces;
using Application.services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class ApplicationDependencyInjection
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ITransactionsService,TransactionsService>();
            services.AddScoped<IIconsService,IconsService>();
            services.AddScoped<ICategoriesService,CategoriesService>();
        }
    }
}
