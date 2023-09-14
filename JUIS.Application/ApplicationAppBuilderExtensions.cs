using Hangfire;
using Microsoft.AspNetCore.Builder;

namespace JUIS.Application
{
    public static class ApplicationAppBuilderExtensions
    {
        public static IApplicationBuilder UseHangfire(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            app.UseHangfireDashboard();
            BackgroundJob.Enqueue(() => Console.WriteLine("Hello world from Hangfire!"));

            return app;
        }
    }
}
