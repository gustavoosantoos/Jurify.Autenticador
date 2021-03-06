﻿using FluentValidation;
using Jurify.Autenticador.Web.Domain.Model.Repositories;
using Jurify.Autenticador.Web.Domain.Model.Services.Abstractions;
using Jurify.Autenticador.Web.Domain.Model.Services.Implementations;
using Jurify.Autenticador.Web.Infrastructure.Database.Context;
using Jurify.Autenticador.Web.Infrastructure.Database.Repositories;
using Jurify.Autenticador.Web.UseCases.Core.Behaviors;
using Jurify.Autenticador.Web.UseCases.Services.Abstractions;
using Jurify.Autenticador.Web.UseCases.Services.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Jurify.Autenticador.Web.Infrastructure.Configuration.DependencyInjection
{
    public static class DependencyInjectionSetup
    {
        public static void AddAutenticadorServices(this IServiceCollection services)
        {
            services.AddSingleton<IHashService, HashService>();
            services.AddSingleton<IGeocodingService, GeocodingService>();

            services.AddDbContext<AutenticadorContext>();
            services.AddDbContext<PerfilOabContext>();
            services.AddEntityFrameworkNpgsql()
               .AddDbContext<PerfilOabContext>()
               .BuildServiceProvider();

            services.AddScoped<IEscritorioRepositorio, EscritorioRepositorio>();
            services.AddScoped<IUsuarioEscritorioRepositorio, UsuarioEscritorioRepositorio>();

            services.AddScoped<IEscritorioServico, EscritorioServico>();
            services.AddScoped<IUsuarioEscritorioServico, UsuarioEscritorioServico>();

            AddMediatr(services);
        }

        private static void AddMediatr(IServiceCollection services)
        {
            var assembly = typeof(Startup).Assembly;

            AssemblyScanner
                .FindValidatorsInAssembly(assembly)
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidateRequestBehavior<,>));

            services.AddMediatR(assembly);
        }
    }
}
