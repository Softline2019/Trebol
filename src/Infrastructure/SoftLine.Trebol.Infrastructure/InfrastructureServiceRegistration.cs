using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SoftLine.Trebol.Application.Contracts.Identity;
using SoftLine.Trebol.Application.Contracts.Infrastructure;
using SoftLine.Trebol.Application.Models.Email;
using SoftLine.Trebol.Application.Models.ImageManagement;
using SoftLine.Trebol.Application.Models.Token;
using SoftLine.Trebol.Application.Persistence;
using SoftLine.Trebol.Infrastructure.MessageImplementation;
using SoftLine.Trebol.Infrastructure.Repositories;
using SoftLine.Trebol.Infrastructure.Services.Auth;
namespace SoftLine.Trebol.Infrastructure;

public static class InfrastructureServiceRegistration
{

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
                                                                IConfiguration configuration
    )
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

        services.AddTransient<IEmailService, EmailService>();
        services.AddTransient<IAuthService, AuthService>();

        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        services.Configure<CloudinarySettings>(configuration.GetSection("CloudinarySettings"));
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

        


        return services;
    }

}
