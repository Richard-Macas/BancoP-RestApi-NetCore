using BancoP.Application.Models;
using BancoP.Application.Models.Cliente;
using MediatR;
using PruebaP.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoP.Application.Commands.ClienteCommands
{
    public class UpdateClienteCommand : IRequest<ResponseModel<Cliente>>
    {
        public ClienteUpdate Cliente { get; set; }

        public UpdateClienteCommand(ClienteUpdate cliente)
        {
            Cliente = cliente;
        }
    }
}
