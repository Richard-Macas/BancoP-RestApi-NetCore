using BancoP.Application.Models;
using MediatR;
using PruebaP.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoP.Application.Queries.CuentaQueries
{
    public class GetCuentaMovimientosByIdQuery : IRequest<ResponseModel<Cuenta>>
    {
        public int Id { get; set; }

        public GetCuentaMovimientosByIdQuery(int id)
        {
            Id = id;
        }
    }
}
