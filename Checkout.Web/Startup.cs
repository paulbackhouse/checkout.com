using AutoMapper;
using Checkout.Application;
using Checkout.Web.App.Extensions;
using Checkout.Web.App.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Checkout.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationServices();
            services.AddMvc();
            services.AddApiVersioningAndDocs();
            services.AddMemoryCache();
            services.AddAutoMapper(typeof(ApplicationMappingProfile));

            return services.AddDb();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            Configure(app, env);

            // TODO: register middleware to handle model validation for Api requests
            app.UseMiddleware(typeof(ApiErrorHandlingMiddleware));
            app.UseStaticFiles();
            app.UseMvcRoutes();
            app.UseApiDocumentation();

        }


        /// <summary>
        /// configure based on environment
        /// </summary>
        void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
        }
    }
}
