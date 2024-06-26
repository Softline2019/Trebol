﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SoftLine.Trebol.Application.Behaviors;
using SoftLine.Trebol.Application.Mappings;

namespace SoftLine.Trebol.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(
                        this IServiceCollection services,
                        IConfiguration configuration
    )
    {
        var mapperConfig = new MapperConfiguration(mc => {
            mc.AddProfile(new MappingProfile());
        });

        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        return services;
    }

}