using BancoP.Application.Models;
using MediatR;
using PruebaP.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoP.Application.Queries.MovimientoQueries
{
    public class GetMovimientoByIdQuery : IRequest<ResponseModel<Movimiento>>
    {
        public int Id { get; set; }

        public GetMovimientoByIdQuery(int id)
        {
            Id = id;
        }
    }
}
