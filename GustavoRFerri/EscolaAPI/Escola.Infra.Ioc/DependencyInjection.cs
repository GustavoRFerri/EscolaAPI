using Escola.Domain.Interfaces;
using Escola.Infra.Data.Context;
using Escola.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Infra.Ioc;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Register your infrastructure services here
        // For example:
        services.AddDbContext<ApplicationDbContext>(options =>
        {

            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                b=> b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
        });

        services.AddScoped<ICursoRepository, CursoRepository>();
        services.AddScoped<IMatriculaRepository, MatriculaRepository>();

        services.AddScoped<INotaRepository, NotaRepository>();
        services.AddScoped<ITurmaRepsitory, TurmaRepository>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        return services;

    }
}
