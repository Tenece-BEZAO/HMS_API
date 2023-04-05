using HMS.BLL.Implementation;
using HMS.DAL.Dtos.Reponses;
using HMS.DAL.Entities.ErrorModel;
using HMS.DAL.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.Extensions.Hosting;
using System.Text.Json;

namespace HMS.BLL.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {

        /*        public static void ConfigureExceptionHandler(this IApplicationBuilder app, IWebHostEnvironment hostEnvironment, ILoggerService logger)
                {

                    app.UseExceptionHandler(appError =>
                    {
                        appError.Run(async context =>
                        {
                            context.Response.ContentType = "application/json";

                            IExceptionHandlerFeature? exceptionHandleFeature = context.Features.Get<IExceptionHandlerFeature>();
                            if (exceptionHandleFeature != null)
                            {
                                context.Response.StatusCode = exceptionHandleFeature.Error switch
                                {
                                    NotFoundException => StatusCodes.Status404NotFound,
                                    _ => StatusCodes.Status500InternalServerError
                                };

                                logger.LogError($"Something went wrong: {exceptionHandleFeature.Error}");
                                var status = 500;
                                switch (exceptionHandleFeature.Error)
                                { 
                                    case InvalidDataException:
                                    case InvalidOperationException:
                                    case KeyNotFoundException:
                                    case ArgumentException:

                                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                                        status = 400;
                                        break;
                                    case DbUpdateException:
                                        context.Response.StatusCode = StatusCodes.Status409Conflict;
                                        status = 409;
                                        break;
                                    default:
                                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                                        break;
                                }
                                ErrorResponse err = new() { Success = false, Status = status };
                                err.Message =
                                    hostEnvironment.IsProduction() && context.Response.StatusCode ==
                                    StatusCodes.Status500InternalServerError
                                        ? "We currently cannot complete this request process. Please retry or contact our support"
                                        : exceptionHandleFeature.Error.Message;

                                var serializerSettings = new JsonSerializerSettings();
                                serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                                string msg = JsonConvert.SerializeObject(err, serializerSettings);
                                await context.Response.WriteAsync(msg);
                            }
                        });
                    });
                }
        */

        public static void ConfigureExceptionHandler(this IApplicationBuilder app, IWebHostEnvironment hostEnvironment, ILoggerService logger)
        {

            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    IExceptionHandlerFeature? exceptionHandleFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (exceptionHandleFeature != null)
                    {
                        var statusCode = StatusCodes.Status500InternalServerError;
                        var errorMessage = "Something went wrong";
                        var ex = exceptionHandleFeature.Error;

                        switch (ex)
                        {
                            case NotFoundException:
                                statusCode = StatusCodes.Status404NotFound;
                                errorMessage = "The requested resource was not found.";
                                break;
                            case InvalidDataException _:
                            case InvalidOperationException _:
                            case ArgumentException _:
                            case KeyNotFoundException _:
                                statusCode = StatusCodes.Status400BadRequest;
                                errorMessage = ex.Message;
                                break;
                            case DbUpdateException _:
                                statusCode = StatusCodes.Status409Conflict;
                                errorMessage = "There was a conflict while saving data.";
                                break;
                            default:
                                break;
                        }

                        logger.LogError($"An error occurred: {ex.Message}");

                        var errorResponse = new ErrorResponse
                        {
                            Success = false,
                            Status = statusCode,
                            Message = errorMessage
                        };

                        var jsonSerializerOptions = new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        };

                        var json = System.Text.Json.JsonSerializer.Serialize(errorResponse, jsonSerializerOptions);

                        await context.Response.WriteAsync(json);
                    }
                });
            });
        }


        public static void ConfigureLoggerService(this IServiceCollection services) =>
           services.AddSingleton<ILoggerService, LoggerService>();
    }

}
