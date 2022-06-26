using BancoP.Application.Models;
using MediatR;
using PruebaP.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoP.Application.Commands.ClienteCommands
{
    public class DeleteClienteCommand : IRequest<ResponseModel<Cliente>>
    {
        public int Id { get; set; }

        public DeleteClienteCommand(int id)
        {
            Id = id;
        }
    }
}
