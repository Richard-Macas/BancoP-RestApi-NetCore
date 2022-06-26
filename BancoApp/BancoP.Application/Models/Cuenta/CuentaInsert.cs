using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoP.Application.Models.Cuenta
{
    public class CuentaInsert
    {
        public int? IdCliente { get; set; }
        public string NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }

        public class CuentaInsertValidation : AbstractValidator<CuentaInsert>
        {
            public CuentaInsertValidation()
            {
                RuleFor(x => x.NumeroCuenta).NotEmpty();
                RuleFor(x => x.TipoCuenta).NotEmpty();
                RuleFor(x => x.SaldoInicial).NotNull().GreaterThanOrEqualTo(0);
                RuleFor(x => x.Estado).NotEmpty();
                RuleFor(x => x.IdCliente).NotEmpty().GreaterThan(0);
            }
        }
    }
}
