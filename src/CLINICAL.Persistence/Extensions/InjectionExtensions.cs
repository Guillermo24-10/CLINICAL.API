using CLINICAL.Application.Interfaces;
using CLINICAL.Persistence.Context;
using CLINICAL.Persistence.Repositories;
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
        public static IServiceCollection AddInjectionPersistence(this IServiceCollection services)
        {
            services.AddSingleton<ApplicationDbContext>();//solo hay una instancia de ApplicationDbContext
            services.AddScoped<IAnalysisRepository,AnalysisRepository>();

            return services;
        }
    }
}
