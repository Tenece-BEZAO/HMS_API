using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HMS.BLL.Extensions
{
    public static class JwtConfiguration
    {
        public static void ConfigureCors(this IServiceCollection services) =>
             services.AddCors(options =>
             {
                 options.AddPolicy("CorsPolicy", builder =>
                 builder.AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader());
             });

        public static void ConfigureEmail(this IServiceCollection services)
        {

            services.Configure<IdentityOptions>(opts => opts.SignIn.RequireConfirmedEmail = true);

            services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromMinutes(60);
            });
        }

        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtConfig");

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new
            SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("JwtConfig:Secret").Value))
                };
            });
        }
    }
}
