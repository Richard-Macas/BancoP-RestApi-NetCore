using BancoP.Application.Models;
using MediatR;
using PruebaP.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoP.Application.Commands.MovimientoCommands
{
    public class UpdateMovimientoCommand : IRequest<ResponseModel<Movimiento>>
    {
        public Movimiento Movimiento { get; set; }

        public UpdateMovimientoCommand(Movimiento movimiento)
        {
            Movimiento = movimiento;
        }
    }
}
