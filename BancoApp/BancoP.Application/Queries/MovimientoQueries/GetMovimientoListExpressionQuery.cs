using BancoP.Application.Models;
using MediatR;
using PruebaP.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BancoP.Application.Queries.MovimientoQueries
{
    public class GetMovimientoListExpressionQuery : IRequest<ResponseModel<List<Movimiento>>>
    {
        public Expression<Func<Movimiento, bool>> Path { get; set; }
        public GetMovimientoListExpressionQuery(Expression<Func<Movimiento, bool>> path)
        {
            Path = path;
        }
    }
}
