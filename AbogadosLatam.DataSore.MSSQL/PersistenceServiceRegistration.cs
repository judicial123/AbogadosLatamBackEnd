using AbogadosLatam.Application.Contracts;
using AbogadosLatam.Application.Contracts.Persistence;
using AbogadosLatam.DataSore.MSSQL.DataBaseContext;
using AbogadosLatam.DataSore.MSSQL.Model.MappingProfiles;
using AbogadosLatam.DataSore.MSSQL.Repositories;
using AbogadosLatam.DataSore.MSSQL.Repositories.Estudio;
using AbogadosLatam.DataSore.MSSQL.Repositories.EstudioEspecialidad;
using AbogadosLatam.DataSore.MSSQL.Repositories.Pais;
using AbogadosLatam.DataSore.MSSQL.Repositories.Sucursal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AbogadosLatam.DataSore.MSSQL;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services
    , IConfiguration configuration)
    {

        services.AddDbContext<AbogadosLatamContext>(
            options => options.UseSqlServer(configuration.GetConnectionString("AbogadosLatamConnectionString")));
        
        services.AddAutoMapper(typeof(ApplicationMappingProfile).Assembly);
        //services.AddScoped(typeof(IQueryRepository<>) ,typeof(QueryRepository<>));
        //services.AddScoped(typeof(ICommandRepository<>) ,typeof(CommandRepository<>));
        services.AddScoped<ICiudadQueryRepository, CiudadQueryRepository>();
        services.AddScoped<ICiudadCommandRepository, CiudadCommandRepository>();
        services.AddScoped<IPaisQueryRepository, PaisQueryRepository>();
        services.AddScoped<IPaisCommandRepository, PaisCommandRepository>();
        
        services.AddScoped<IEspecialidadCommandRepository, EspecialidadCommandRepository>();
        services.AddScoped<IEspecialidadQueryRepository, EspecialidadQueryRepository>();

        services.AddScoped<IEstudioCommandRepository, EstudioCommandRepository>();
        services.AddScoped<IEstudioQueryRepository, EstudioQueryRepository>();
        
        services.AddScoped<ISucursalCommandRepository, SucursalCommandRepository>();
        services.AddScoped<ISucursalQueryRepository, SucursalQueryRepository>();

        services.AddScoped<IEstudioEspecialidadCommandRepository, EstudioEspecialidadCommandRepository>();
        services.AddScoped<IEstudioEspecialidadQueryRepository, EstudioEspecialidadQueryRepository>();

        return services;

    }
}