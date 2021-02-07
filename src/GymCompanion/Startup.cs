using CQRSCore.Interfaces;
using GymCompanion.BusinessLogic.Commands;
using GymCompanion.BusinessLogic.Queries;
using GymCompanion.BusinessLogic.Validators;
using GymCompanion.Data;
using GymCompanion.Data.Models;
using GymCompanion.Models;
using GymCompanion.Models.Commands;
using GymCompanion.Models.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDbCore;
using MongoDbCore.Interfaces;
using System;
using System.Collections.Generic;

namespace GymCompanion
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
            services.AddScoped<IMongoDbDatabaseFactory, MongoDbDatabaseFactory>();
            services.AddScoped<IData<DeviceDataModel>, GenericData<DeviceDataModel>>();
            services.AddScoped<IQueryHandler<GetDeviceListQuery, IList<DeviceModel>>, GetDeviceListQueryHandler>();
            services.AddScoped<IQueryHandler<GetDeviceQuery, DeviceModel>, GetDeviceQueryHandler>();
            services.AddScoped<ICommandHandler<RemoveDeviceCommand>, RemoveDeviceCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateOrAddDeviceCommand>, UpdateOrAddDeviceCommandHandler>();
            services.AddScoped<IValidator<RemoveDeviceCommand>, RemoveDeviceCommandValidator>();

            services.AddControllersWithViews();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";
                spa.Options.StartupTimeout = new TimeSpan(0, 5, 0);

                if (env.IsDevelopment())
                {
                    // Run directly with frontend
                    // spa.UseAngularCliServer(npmScript: "start");

                    // Run frontend seperatly from cd ClientApp and npm start
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
                }
            });
        }
    }
}
