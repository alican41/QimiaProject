using Microsoft.Extensions.DependencyInjection;
using QimiaProject.Business.Abstracts;
using QimiaProject.Business.Implementations;
using QimiaProject.Business.Implementations.MapperProfiles;
using System.Reflection;

namespace QimiaProject.Business.DependencyInjection;

public static class AddBussinessLayer
{
    public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
    {

        AddMediatRHandlers(services);
        AddManagers(services);
        AddAutoMapper(services);

        return services;
    }

    private static void AddMediatRHandlers(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }

    private static void AddManagers(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IAuthManager, AuthManager>();
        serviceCollection.AddScoped<IReservationManager, ReservationManager>();
        serviceCollection.AddScoped<IUserManager, UserManager>();
        serviceCollection.AddScoped<IBookManager, BookManager>();
        serviceCollection.AddScoped<IRequestManager, RequestManager>();
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MapperProfile));
    }
}
