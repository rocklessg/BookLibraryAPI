using BookLibrary.Domain.Entities;
using BookLibrary.Domain.Services.InfrastructureServices;
using BookLibrary.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BookLibrary.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static void DomainServicesResolve(this IServiceCollection services)
        {
            services.AddScoped<IBookQueryCommand<Book>, BookQueryCommand<Book>>();
            services.AddScoped<ICategoryQueryCommand<Category>, CategoryQueryCommand<Category>>();
        }
    }
}
