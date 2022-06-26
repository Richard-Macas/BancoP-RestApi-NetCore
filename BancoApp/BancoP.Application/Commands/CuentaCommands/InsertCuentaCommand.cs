using BancoP.Application.Models;
using BancoP.Application.Models.Cuenta;
using MediatR;
using PruebaP.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoP.Application.Commands.CuentaCommands
{
    public class InsertCuentaCommand : IRequest<ResponseModel<Cuenta>>
    {
        public CuentaInsert Cuenta { get; set; }

        public InsertCuentaCommand(CuentaInsert cuenta)
        {
            Cuenta = cuenta;
        }
    }
}
