using CLINICAL.Persistence.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Persistence.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionPersistencia(this IServiceCollection services)
        {
            services.AddSingleton<ApplicationDbContext>();//solo hay una instancia de ApplicationDbContext

            return services;
        }
    }
}
