using FluentValidation;
using HMS.BLL.Implementation;
using HMS.BLL.Interfaces;
using HMS.DAL.Context;
using HMS.DAL.Dtos.Requests;
using HMS.DAL.Entities;
using HMS.DAL.Implementation;
using HMS.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace HMS.BLL.Extensions
{

   public static class Middleware
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork<HmoDbContext>>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IAdminService, AdminService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IClaimServices, ClaimServices>();
            services.AddTransient<IValidator<UpdateRequest>, UpdateRequestValidator>();

            //services.AddSingleton<IHttpContextAccessor>();

            //services.AddSingleton<IHttpContextAccessor>();

        }
        public static IServiceCollection AddEmailService(this IServiceCollection services, IConfiguration configuration)
        {
            var emailConfig = configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailService, EmailService>();
            services.AddSingleton<IUrlHelperFactory, UrlHelperFactory>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped<IUserTwoFactorTokenProvider<AppUser>, MyTokenProvider>();
            return services;
        }
    }
}
    