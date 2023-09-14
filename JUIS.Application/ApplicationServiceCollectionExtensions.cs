using Hangfire;
using JUIS.Domain.Interfaces;
using JUIS.Application.Jobs;
using JUIS.Application.HangfireJobs;
using JUIS.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace JUIS.Application
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddHangfire(this IServiceCollection services, string connectionString)
        {
            services.AddHangfire(configuration => configuration
                    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                    .UseSimpleAssemblyNameTypeSerializer()
                    .UseRecommendedSerializerSettings()
                    // get connectionstring from configuration within .UseSqlServerStorage
                    .UseSqlServerStorage(connectionString)
                    );

            // Add the processing server as IHostedService
            services.AddHangfireServer();

            services.AddScoped<IUserJob, UserJob>();
            services.AddScoped<IJobScheduler, JobScheduler>();
            services.AddScoped<IUserRepository, UserRepository>();

            //services.AddScoped<INotificationService, SignalRNotificationService>();


            return services;
        }
    }
}
