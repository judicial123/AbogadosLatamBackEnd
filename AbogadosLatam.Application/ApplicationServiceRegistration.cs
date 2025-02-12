using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AbogadosLatam.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        //services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        services.AddAutoMapper(typeof(MappingProfiles.PaisProfile).Assembly);

        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}