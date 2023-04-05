
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

        public static void ProviderServices(this IServiceCollection services)
        {
            services.AddScoped<IProviderService, ProviderService>();
        }

        public static void EnrolleeServices(this IServiceCollection services)
        {
            services.AddScoped<IEnrolleeService, EnrolleeService>();
        }

        public static void PlanServices(this IServiceCollection services)
        {
            services.AddScoped<IPlanService, PlanService>();
        }

        public static void DrugServices(this IServiceCollection services)
        {
            services.AddScoped<IDrugService, DrugService>();
        }
    }
}
