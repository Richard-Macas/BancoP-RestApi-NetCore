using BancoP.Application.Models;
using BancoP.Application.Models.Movimiento;
using MediatR;
using PruebaP.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoP.Application.Commands.MovimientoCommands
{
    public class InsertMovimientoCommand : IRequest<ResponseModel<Movimiento>>
    {
        public MovimientoInsert Movimiento { get; set; }
        public bool EsDeposito { get; set; }

        public InsertMovimientoCommand(MovimientoInsert movimiento, bool esDeposito)
        {
            Movimiento = movimiento;
            EsDeposito = esDeposito;
        }
    }
}
