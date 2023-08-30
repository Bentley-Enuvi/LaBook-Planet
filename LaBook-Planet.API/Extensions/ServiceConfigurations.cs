using LaBook_Planet.API.Library.Domain.Services.Implementations;
using LaBook_Planet.API.Library.Domain.Services.Interfaces;
using LaBook_Planet.API.LibraryCore.API.Repositories;
using Library.Core.Interfaces.Services;

namespace Library.API.Extensions;

public static class ServiceConfigurations
{
    public static void AddServicesExtension(this IServiceCollection services)
    {
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IBookService, BookService>();
    }
}