using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentRegistration.Application.Core;
using StudentRegistration.Application.Services;

namespace StudentRegistration.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IStudentService, StudentService>();

        return services;
    }
}