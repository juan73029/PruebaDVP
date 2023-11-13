using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PruebaDVP.Core.Autenticacion;
using PruebaDVP.Core.Autenticacion.Interfaces;
using PruebaDVP.Core.MapperDTOs;
using PruebaDVP.Core.Services;
using PruebaDVP.Core.Services.Interfaces;
using PruebaDVP.Data;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Emit;
using System.Text;

namespace PruebaDVP.Core;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddData(configuration);
        services.AddAutoMapper(typeof(AutoMapperProfile));
        services.AddScoped(typeof(IService<,>), typeof(Service<,>));
        services.AddScoped<IPersonaService, PersonaService>();
        services.AddScoped<ITipoIdentificacionService, TipoIdentificacionService>();
        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<IAutenticacionService, AutenticacionService>();
        return services;
    }
}

