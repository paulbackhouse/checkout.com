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
            var baseXmlDir = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);


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
                // general doc info
                options.SwaggerDoc("v1.0", GetInfo());

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

                // add the xml comment files for documentation
                foreach (var fi in baseXmlDir.EnumerateFiles("*.xml"))
                {
                    options.IncludeXmlComments(fi.FullName);
                }

            });
        }

        private static Info GetInfo()
        {
            return new Info
            {
                Title = "Checkout.com Cart API",
                Version = "v1.0",
                Contact = GetContactInfo(),
                Description = "Checkout.com cart prototype REST Api. Use version \"1.0\" where asked"
            };
        }

        private static Contact GetContactInfo()
        {
            return new Contact
            {
                 Email = "paul.k.backhouse@gmail.com",
                 Name = "Paul Backhouse"
            };
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
