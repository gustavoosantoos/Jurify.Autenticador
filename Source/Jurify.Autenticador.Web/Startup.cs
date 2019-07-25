// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Jurify.Autenticador.Web.Infrastructure.Configuration.DependencyInjection;
using Jurify.Autenticador.Web.Infrastructure.Configuration.IdentityServer;
using Jurify.Autenticador.Web.Infrastructure.Filters;
using Jurify.Autenticador.Web.UseCases.Services.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

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


            var builder = services.AddIdentityServer()
                .AddInMemoryIdentityResources(IdentityServerConfiguration.Resources.GetIdentityResources())
                .AddInMemoryApiResources(IdentityServerConfiguration.ApiResources.GetApiResources())
                .AddInMemoryClients(IdentityServerConfiguration.Clients.GetClients())
                .AddProfileService<UserProfileService>()
                .AddResourceOwnerValidator<UserPasswordValidationService>()
                .AddDeveloperSigningCredential()
                .AddCorsPolicyService<CorsPolicyService>();

            services.AddAuthentication()
                .AddJwtBearer(config =>
                {
                    config.Authority = Configuration["Authentication:Authority"];
                    config.RequireHttpsMetadata = false;
                    config.Audience = Configuration["Authentication:ResourceName"];
                });

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ExceptionFilter));
            }).AddJsonOptions(options => 
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Jurify.Autenticador API", Version = "v1" });
            });

            services.AddAutenticadorServices();
        }

        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseCors("Default");
            app.UseIdentityServer();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Jurify.Autenticador API");
            });

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}