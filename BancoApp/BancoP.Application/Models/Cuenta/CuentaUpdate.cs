using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoP.Application.Models.Cuenta
{
    public class CuentaUpdate
    {
        public int Id { get; set; }
        public int? IdCliente { get; set; }
        public string NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }

        public class CuentaUpdateValidation : AbstractValidator<CuentaUpdate>
        {
            public CuentaUpdateValidation()
            {
                RuleFor(x => x.Id).NotEmpty().GreaterThan(0);
                RuleFor(x => x.NumeroCuenta).NotEmpty();
                RuleFor(x => x.TipoCuenta).NotEmpty();
                RuleFor(x => x.SaldoInicial).NotNull().GreaterThanOrEqualTo(0);
                RuleFor(x => x.Estado).NotEmpty();
                RuleFor(x => x.IdCliente).NotEmpty().GreaterThan(0);
            }
        }
    }
}
