using HMS.BLL.Implementation;
using HMS.DAL.Context;
using HMS.DAL.Implementation;
using HMS.DAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;


namespace HMS.BLL.Extensions
{
   public static class Middleware
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork<HmoDbContext>>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
        }
    }
}
    