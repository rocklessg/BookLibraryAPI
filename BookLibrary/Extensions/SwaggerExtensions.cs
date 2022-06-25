using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace BookLibrary.Extensions
{
    public static class SwaggerExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            // This method gets called by the runtime from the startup "ConfigureServices()" to add swagger.
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Book Library API",
                    Version = "v1",
                    Description = @"API service for creating, deleting, and updating books and categories entries in a library",
                    Contact = new OpenApiContact
                    {
                        Name = "Abdulhafiz Suleiman",
                        Email = "hafizdanmaigoro@gmail.com"
                    }
                });
            });
        }
    }
}
