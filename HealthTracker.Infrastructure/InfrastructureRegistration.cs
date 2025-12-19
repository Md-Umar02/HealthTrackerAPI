using HealthTracker.Domain.Contracts;
using HealthTracker.Infrastructure.Repositoies;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthTracker.Infrastructure
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IHealthMetricRepository, HealthMetricRepository>();
            services.AddScoped<IMetricTypeRepository, MetricTypeRepository>();
            return services;
        }
    }
}
