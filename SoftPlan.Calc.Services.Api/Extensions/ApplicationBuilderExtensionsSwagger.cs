using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace SoftPlan.Calc.Services.Api.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class ApplicationBuilderExtensionsSwagger
    {
        public static void UseSwaggerInApplication(this IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Seleção de pessoa Desenvolvedora .Net Core - V1");
            });
        }
    }
}
