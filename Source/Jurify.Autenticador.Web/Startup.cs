// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Jurify.Autenticador.Web.Infrastructure.Configuration.DependencyInjection;
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
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddCors(setup =>
            {
                setup.AddPolicy("Default", options =>
                {
                    options.AllowAnyHeader();
                    options.AllowAnyOrigin();
                    options.AllowAnyMethod();
                    options.AllowCredentials();
                });
            });

            services.AddMvc();

            var builder = services.AddIdentityServer()
                .AddInMemoryIdentityResources(Configuration.GetSection("IdentityResources"))
                .AddInMemoryApiResources(Configuration.GetSection("ApiResources"))
                .AddInMemoryClients(Configuration.GetSection("Clients"))
                .AddProfileService<UserProfileService>()
                .AddResourceOwnerValidator<UserPasswordValidationService>();

            services.AddAutenticadorServices();
            
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

            app.UseCors("Default");

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