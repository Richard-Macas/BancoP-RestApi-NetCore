using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoP.Application.Models.Movimiento
{
    public class MovimientoInsert
    {
        public int? IdCuenta { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }

        public class MovimientoInsertValidation : AbstractValidator<MovimientoInsert>
        {
            public MovimientoInsertValidation()
            {
                RuleFor(x => x.IdCuenta).NotEmpty().GreaterThan(0);
                RuleFor(x => x.Fecha).NotEmpty();
                RuleFor(x => x.Valor).NotEmpty().GreaterThan(0);

            }
        }
    }
}
