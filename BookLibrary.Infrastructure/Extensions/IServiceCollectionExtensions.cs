﻿using BookLibrary.Infrastructure.Services.Abstractions;
using BookLibrary.Infrastructure.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void InfrastructureServicesResolve(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ICategoryService, CategoryService>();
        }
    }
}
