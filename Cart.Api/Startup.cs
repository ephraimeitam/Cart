using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Cart.Api.Accessor;
using Cart.Api.Manager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Cart
{
    public class Startup
    {

        public Startup(IWebHostEnvironment env)
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();
            
        }
        

        
        public IConfigurationRoot Configuration { get; private set; }
        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        
            services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerDocument(document =>
            {
                document.DocumentName = "v1";
                document.Title = "Cart API ";
                document.Description = "Cart API";
            });
            
        }


        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType<CartAccessor>().As<ICartAccessor>().AsImplementedInterfaces();
            builder.RegisterType<CartManager>().As<ICartManager>().InstancePerLifetimeScope();
            builder.RegisterType<CartDB>().AsSelf().SingleInstance();
           
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            var basePath = Environment.GetEnvironmentVariable("SERVICE_BASE_PATH")?.Insert(0, "/") ?? string.Empty;
            app.UsePathBase(basePath);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwaggerUi3(config =>
                config.TransformToExternalPath =
                    (route, request) => (route.StartsWith(basePath) ? "" : basePath) + route);
            app.UseOpenApi(config => config.PostProcess = (document, request) =>
            {
                document.BasePath = basePath;
                document.Host = null;
            });
            AutofacContainer = app.ApplicationServices.GetAutofacRoot();

        }
    }
}
