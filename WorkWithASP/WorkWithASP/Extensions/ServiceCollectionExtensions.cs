using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using UsersAndRewards.Common;
using UsersAndRewards.MemoryStorage;

namespace WorkWithASP.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMemoryStorage(this IServiceCollection services)
        {
            services.AddSingleton<IStorage>(new MemoryStorage());
        }
    }
}
