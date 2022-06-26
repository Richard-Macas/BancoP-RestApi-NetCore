using BancoP.Application.Models.Cliente;
using BancoP.Application.Models.Cuenta;
using BancoP.Application.Models.Movimiento;
using BancoP.Application.Models.Persona;
using BancoP.Application.Queries.MovimientoQueries;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoP.Application.Extensions
{
    public static class ValidationsCollectionsExtensions
    {
        public static void AddValidations(this IServiceCollection services)
        {
            services.AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<PersonaInsert>());
            services.AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<PersonaUpdate>());

            services.AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<ClienteInsert>());
            services.AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<ClienteUpdate>());

            services.AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<CuentaInsert>());
            services.AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<CuentaUpdate>());

            services.AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<MovimientoInsert>());
            services.AddFluentValidation(cfg => cfg.RegisterValidatorsFromAssemblyContaining<MovimientoReport>());
        }
    }
}
