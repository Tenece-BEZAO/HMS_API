using HMS.BLL.Extensions;
using HMS.DAL.Configuration.MappingConfiguration;
using HMS.DAL.Interfaces;
using Microsoft.OpenApi.Models;
using NLog;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;


namespace HMS.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(),"/nlog.config"));
            builder.Services.ConfigureLoggerService();
            builder.Services.ConfigureCors();
            builder.Services.ConfigureJWT(builder.Configuration);

            builder.Services.AddControllers();
            builder.Services.AddDatabaseConnection();
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            builder.Services.AddAutoMapper(Assembly.Load("HMS.DAL"));

            builder.Services.RegisterServices();

            builder.Services.ReportServices();
            builder.Services.AppointmentServices();

            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "Standard Authorization Header Using the Bearer Scheme (\"bearer {token}\")",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });
            
            builder.Services.AddEndpointsApiExplorer();
            var app = builder.Build();
            var logger = app.Services.GetRequiredService<ILoggerService>();
            app.ConfigureExceptionHandler(logger);

            if (app.Environment.IsProduction())
                app.UseHsts();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
