﻿using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LanguageLearning.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }
    }
}
