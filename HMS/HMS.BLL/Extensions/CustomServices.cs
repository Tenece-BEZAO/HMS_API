
using HMS.BLL.Implementation;
using HMS.BLL.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HMS.BLL.Extensions
{
    public static class CustomServices
    {
        public static void AppointmentServices(this IServiceCollection services)
        {
            services.AddScoped<IAppointmentService, AppointmentService>();
        }


        public static void ReportServices(this IServiceCollection services)
        {
            services.AddScoped<IReportService, ReportService>();
        }
    }
}
