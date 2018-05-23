using Checkout.Web.App.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Checkout.Web.App.Extensions
{
    /// <summary>
    /// Configuration of Swagger related
    /// Ref: https://swagger.io/
    /// Ref: https://github.com/domaindrivendev/Swashbuckle.AspNetCore/blob/master/README.md
    /// Ref: https://blog.jimismith.me/blogs/api-versioning-in-aspnet-core-with-nice-swagg
    /// </summary>
    public static class ApiExtensions
    {

        public static IServiceCollection AddApiVersioningAndDocs(this IServiceCollection services)
        {
            // project xml file ref. contains xml generated comments for use in swagger
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            // set the versioning 
            return services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0); // default api version
                options.AssumeDefaultVersionWhenUnspecified = true; 
                options.ApiVersionReader = new MediaTypeApiVersionReader(); // read the version number from the accept header
            })

            // set swagger api documentation generation 
            .AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1.0", new Info { Title = "Checkout.com Cart API", Version = "v1.0" });
                options.DocInclusionPredicate((docName, apiDesc) =>
                {
                    var actionApiVersionModel = apiDesc.ActionDescriptor?.GetApiVersion();
                    // would mean this action is unversioned and should be included everywhere
                    if (actionApiVersionModel == null)
                    {
                        return true;
                    }
                    if (actionApiVersionModel.DeclaredApiVersions.Any())
                    {
                        return actionApiVersionModel.DeclaredApiVersions.Any(v => $"v{v.ToString()}" == docName);
                    }
                    return actionApiVersionModel.ImplementedApiVersions.Any(v => $"v{v.ToString()}" == docName);
                });

                options.OperationFilter<ApiVersionOperationFilter>();
                options.IncludeXmlComments(xmlPath);

            });
        }

        public static IApplicationBuilder UseApiDocumentation(this IApplicationBuilder app)
        {
            return app
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    // add more versions as required
                    //c.SwaggerEndpoint("/swagger/v1.1/swagger.json", "Versioned Api v1.1");
                    c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Versioned Api v1.0");
                });
        }

    }
}
