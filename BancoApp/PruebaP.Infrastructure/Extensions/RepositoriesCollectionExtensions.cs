using Microsoft.Extensions.DependencyInjection;
using PruebaP.Infrastructure.Repositories;
using PruebaP.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaP.Infrastructure.Extensions
{
    public static class RepositoriesCollectionExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IRepositoryCliente, RepositoryCliente>();
            services.AddTransient<IRepositoryPersona, RepositoryPersona>();
            services.AddTransient<IRepositoryCuenta, RepositoryCuenta>();
            services.AddTransient<IRepositoryMovimiento, RepositoryMovimiento>();
        }
    }
}
