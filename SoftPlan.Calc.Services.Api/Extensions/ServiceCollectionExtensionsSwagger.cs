using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;

namespace SoftPlan.Calc.Services.Api.Extensions
{
    public static class ServiceCollectionExtensionsSwagger
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.DescribeAllEnumsAsStrings();
                c.DescribeAllParametersInCamelCase();
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Empresa Softplan - Seleção de pessoa Desenvolvedora .Net Core",
                    Version = "v1",
                    Description = "Se você chegou ate aqui é porque se interessou por mim kkkk.",
                    Contact = new Contact
                    {
                        Name = "Artur Ribeiro",
                        Email = "arturrj@gmail.com"
                    }
                });

                var xmlComments = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, $"{PlatformServices.Default.Application.ApplicationName}.xml");
                c.IncludeXmlComments(xmlComments);
            });
        }
    }
}