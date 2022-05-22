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
            services.AddScoped<IBookLibraryGenericQuery<Book>, BookLibraryGenericQuery<Book>>();
            services.AddScoped<IBookLibraryGenericQuery<Category>, BookLibraryGenericQuery<Category>>();
        }
    }
}
