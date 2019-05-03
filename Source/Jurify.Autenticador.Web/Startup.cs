// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Jurify.Autenticador.Web.Domain.Model.Repositories;
using Jurify.Autenticador.Web.Domain.Model.Services.Abstractions;
using Jurify.Autenticador.Web.Domain.Model.Services.Implementations;
using Jurify.Autenticador.Web.Infrastructure.Database.Context;
using Jurify.Autenticador.Web.Infrastructure.Database.Repositories;
using Jurify.Autenticador.Web.UseCases.Services.Abstractions;
using Jurify.Autenticador.Web.UseCases.Services.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Jurify.Autenticador.Web
{
    public class Startup
    {
        public IHostingEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var builder = services.AddIdentityServer()
                .AddInMemoryIdentityResources(Configuration.GetSection("IdentityResources"))
                .AddInMemoryApiResources(Configuration.GetSection("ApiResources"))
                .AddInMemoryClients(Configuration.GetSection("Clients"))
                .AddProfileService<UserProfileService>()
                .AddResourceOwnerValidator<UserPasswordValidationService>();

            services.AddSingleton<IHashService, HashService>();

            services.AddDbContext<AutenticadorContext>();

            services.AddScoped<IOfficeRepository, OfficeRepository>();
            services.AddScoped<IOfficeService, OfficeService>();
            services.AddScoped<IOfficeUserRepository, OfficeUserRepository>();
            services.AddScoped<IOfficeUserService, OfficeUserService>();
            services.AddScoped<SeedDatabase>();

            if (Environment.IsDevelopment())
            {
                builder.AddDeveloperSigningCredential();
            }
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "users",
                   template: "{area:exists}/{controller=Account}/{action=Login}/{id?}");

                routes.MapRoute(
                  name: "default",
                  template: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}