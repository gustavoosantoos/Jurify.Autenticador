using FluentValidation;
using Jurify.Autenticador.Web.Domain.Model.Repositories;
using Jurify.Autenticador.Web.Domain.Model.Services.Abstractions;
using Jurify.Autenticador.Web.Domain.Model.Services.Implementations;
using Jurify.Autenticador.Web.Infrastructure.Database.Context;
using Jurify.Autenticador.Web.Infrastructure.Database.Repositories;
using Jurify.Autenticador.Web.UseCases.Core.Behaviors;
using Jurify.Autenticador.Web.UseCases.Services.Abstractions;
using Jurify.Autenticador.Web.UseCases.Services.Concrete;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Jurify.Autenticador.Web.Infrastructure.Configuration.DependencyInjection
{
    public static class DependencyInjectionSetup
    {
        public static void AddAutenticadorServices(this IServiceCollection services)
        {
            services.AddSingleton<IHashService, HashService>();

            services.AddDbContext<AutenticadorContext>();
            services.AddScoped<SeedDatabase>();

            services.AddScoped<IOfficeRepository, OfficeRepository>();
            services.AddScoped<IOfficeUserRepository, OfficeUserRepository>();

            services.AddScoped<IOfficeService, OfficeService>();
            services.AddScoped<IOfficeUserService, OfficeUserService>();

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
