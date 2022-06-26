using BancoP.Application.Models;
using BancoP.Application.Models.Movimiento;
using MediatR;
using PruebaP.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoP.Application.Queries.MovimientoQueries
{
    public class GetMovimientosCuentaByFilterListQuery : IRequest<ResponseModel<List<MovimientoReport>>>
    {
        public DateTime From { get; set; } 
        public DateTime To {get; set;}
        public int Id { get; set; }

        public GetMovimientosCuentaByFilterListQuery(DateTime from, DateTime to, int id)
        {
            From = from;
            To = to;
            Id = id;
        }

    }
}
