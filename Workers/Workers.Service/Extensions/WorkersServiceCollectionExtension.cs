using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Workers.DataAccess.Repository;

namespace Workers.Service.Extensions
{
    public static class WorkersServiceCollectionExtension
    {
        public static IServiceCollection AddWorkersServices(this IServiceCollection services)
        {
            services.AddSingleton<IWorkerRepository, WorkerRepository>();
            services.AddSingleton<IWorkerService, WorkerService>();
            return services;
        }
    }
}


