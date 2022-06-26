using BancoP.Application.Models;
using BancoP.Application.Models.Cuenta;
using MediatR;
using PruebaP.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoP.Application.Commands.CuentaCommands
{
    public class UpdateCuentaCommand : IRequest<ResponseModel<Cuenta>>
    {
        public CuentaUpdate Cuenta { get; set; }

        public UpdateCuentaCommand(CuentaUpdate cuenta)
        {
            Cuenta = cuenta;
        }
    }
}
