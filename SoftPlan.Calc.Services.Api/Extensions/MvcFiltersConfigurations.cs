using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Softplan.Calc.Services.Api.Middlewares;

namespace Softplan.Calc.Services.Api.Extensions
{
    public static class MvcFiltersConfigurations
    {
        public static MvcOptions ConfigureFilters(this MvcOptions options)
        {
            options.Filters.Add<DomainNotificationHandlerFilter>();

            return options;
        }
    }
}