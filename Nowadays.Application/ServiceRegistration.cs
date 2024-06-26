﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Nowadays.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection collection)
        {
            collection.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            //collection.AddHttpClient();
        }
    }
}
