﻿using System;
using System.Net.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Steeltoe.CircuitBreaker.Hystrix;
using Steeltoe.CloudFoundry.Connector.MySql.EFCore;
using Steeltoe.Common.Discovery;
using Steeltoe.Discovery.Client;
using Steeltoe.Management.CloudFoundry;
using Steeltoe.Security.Authentication.CloudFoundry;
using Timesheets.Data;
using Timesheets.ProjectClient;

namespace TimesheetsServer
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
            services.AddCloudFoundryActuators(Configuration);

            services.AddControllers(mvcOptions =>
            {
                if (!Configuration.GetValue("DISABLE_AUTH", false))
                {
                    // Set Authorized as default policy
                    var policy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                        .RequireAuthenticatedUser()
                        .RequireClaim("scope", "uaa.resource")
                        .Build();

                    mvcOptions.Filters.Add(new AuthorizeFilter(policy));
                }
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddCloudFoundryJwtBearer(Configuration);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDbContext<TimeEntryContext>(options => options.UseMySql(Configuration));
            services.AddScoped<ITimeEntryDataGateway, TimeEntryDataGateway>();
            services.AddDiscoveryClient(Configuration);
            services.AddSingleton<IProjectClient>(sp =>
            {
                 var handler = new DiscoveryHttpClientHandler(sp.GetService<IDiscoveryClient>());
             var httpClient = new HttpClient(handler, false)
               
                {
                    BaseAddress = new Uri(Configuration.GetValue<string>("REGISTRATION_SERVER_ENDPOINT"))
                };

                var logger = sp.GetService<ILogger<ProjectClient>>();
               
                var contextAccessor = sp.GetService<IHttpContextAccessor>();
                return new ProjectClient(
                    httpClient, logger,
                    () => contextAccessor.HttpContext.GetTokenAsync("access_token")
                );
            });
         services.AddHystrixMetricsStream(Configuration); 
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCloudFoundryActuators();
            app.UseDiscoveryClient();
             app.UseHystrixMetricsStream();
           app.UseHystrixRequestContext();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
