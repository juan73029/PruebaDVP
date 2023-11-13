using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PruebaDVP.Data.Models.DB;
using PruebaDVP.Data.Services;
using PruebaDVP.Data.Services.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace PruebaDVP.Data;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
    {
        string defaultConnectionString = configuration.GetConnectionString("DBConnection") ?? throw new Exception("No database info");
        try
        {
            services.AddDbContext<PruebaDoubleVpartnersContext>(options =>
     options.UseSqlServer(defaultConnectionString), ServiceLifetime.Transient
     );
        }
        catch (Exception ex)
        {
            throw ex;
        }


        services.AddScoped(typeof(IContextService<>), typeof(ContextService<>));
        services.AddScoped<IPersonaContextService, PersonaContextService>();
        services.AddScoped<ITipoIdentificacionContextService, TipoIdentificacionContextService>();
        services.AddScoped<IUsuarioContextService, UsuarioContextService>();

        return services;
    }
}

