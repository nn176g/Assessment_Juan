using Assessment_Juan.Business.Business;
using Assessment_Juan.Business.Interfaces;
using Assessment_Juan.Commands.Handlers;
using Assessment_Juan.Impl;
using Assessment_Juan.Integracion.Context;
using Assessment_Juan.Integracion.Interfaces;
using Assessment_Juan.Integracion.Repositorio;
using Assessment_Juan.Model.Entities;
using Assessment_Juan.ServiceBus;
using Inventory.Api.Config;
using Inventory.Api.Events.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;

namespace Assessment_Juan
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            AddSwagger(services);
            services.AddDbContext<myAssessmentContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //services.AddMvc();
            services.AddScoped<ICompraBusiness, CompraBusiness>();
            services.AddScoped<ICompraRepositorio, CompraRepositorio>();
            services.AddScoped<IVentaBusiness, VentaBusiness>();
            services.AddScoped<IVentaRepositorio, VentaRepositorio>();
            services.AddScoped<IInventarioBusiness, InventarioBusiness>();
            services.AddScoped<IInventarioRepositorio, InventarioRepositorio>();
            //Service Bus
            services.AddTransient<IServiceBus, ServiceBus.ServiceBus>();
            services.AddTransient<IHandler<CreateCommand>, CreateHandler>();

            // Receiver bus
            services.AddSingleton<IServiceBus, ServiceBus.ServiceBus>();
            // Handlers
            //services.AddSingleton<IHandler<IEnumerable<Producto>>, ProductStockEventHandler>();
            services.AddSingleton<IHandlerEvents<IEnumerable<Producto>>, ProductStockEventHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
            {
                options.AllowAnyMethod();
                options.AllowAnyHeader();
                options.AllowAnyOrigin();
            });
            app.UseCors("ClientPermission");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Foo API V1");
            });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(options =>
            {
                options.WithOrigins("http://localhost:3000/");
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            });
            // Run handlers
            app.UseEventHandler();

        }
        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Foo {groupName}",
                    Version = groupName
                });
            });
        }

    }
}
