using BancoP.Application.Models;
using MediatR;
using PruebaP.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoP.Application.Queries.MovimientoQueries
{
    public class GetMovimientoListQuery : IRequest<ResponseModel<List<Movimiento>>>
    {

    }
}
