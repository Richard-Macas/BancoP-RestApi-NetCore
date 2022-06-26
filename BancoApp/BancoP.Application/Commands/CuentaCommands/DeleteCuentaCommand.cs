using BancoP.Application.Models;
using MediatR;
using PruebaP.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoP.Application.Commands.CuentaCommands
{
    public class DeleteCuentaCommand : IRequest<ResponseModel<Cuenta>>
    {
        public int Id { get; set; }

        public DeleteCuentaCommand(int id)
        {
            Id = id;
        }
    }
}
