using Application.Common.Interfaces.RcVaultGate;
using ExternalServices.RcVaultGate;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IRcVaultProxy, RcVaultProxy>();

            return services;
        }
    }
}
