﻿using Microsoft.Extensions.DependencyInjection;
using ScientificWork.UseCases.Users.AuthenticateUser;

namespace ScientificWork.Web.Infrastructure.DependencyInjection;

/// <summary>
/// Register AutoMapper dependencies.
/// </summary>
public class AutoMapperModule
{
    /// <summary>
    /// Register dependencies.
    /// </summary>
    /// <param name="services">Services.</param>
    public static void Register(IServiceCollection services)
    {
        services.AddAutoMapper(
            typeof(TokenModel).Assembly);
    }
}
