using BancoP.Application.Models;
using MediatR;
using PruebaP.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoP.Application.Commands.MovimientoCommands
{
    public class DeleteMovimientoCommand : IRequest<ResponseModel<Movimiento>>
    {
        public int Id { get; set; }

        public DeleteMovimientoCommand(int id)
        {
            Id = id;
        }
    }
}
