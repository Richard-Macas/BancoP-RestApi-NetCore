using BancoP.Application.Models;
using BancoP.Application.Models.Cliente;
using MediatR;
using PruebaP.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoP.Application.Commands.ClienteCommands
{
    public class InsertClienteCommand : IRequest<ResponseModel<Cliente>>
    {
        public ClienteInsert Cliente { get; set; }

        public InsertClienteCommand(ClienteInsert cliente)
        {
            Cliente = cliente;
        }
    }
}
