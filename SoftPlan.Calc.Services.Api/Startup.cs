using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Softplan.Calc.Services.Api.App;
using Softplan.Calc.Services.Api.Extensions;
using SoftPlan.Calc.Queries.Juros;
using SoftPlan.Calc.Services.Api.Extensions;

namespace SoftPlan.Calc.Services.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment configuration)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(configuration.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{configuration.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc(options => { options.ConfigureFilters(); })
                .ConfigureJsonOptions()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.ConfigureSwagger();

            // Adding MediatR for Domain Events and Notifications
            services.AddMediatR(typeof(Startup));

            services.AddScoped<ITaxaQueries, TaxaQueries>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwaggerInApplication(env);
        }
    }
}
