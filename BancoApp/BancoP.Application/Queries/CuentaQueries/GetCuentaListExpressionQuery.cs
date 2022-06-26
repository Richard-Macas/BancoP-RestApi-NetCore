using BancoP.Application.Models;
using MediatR;
using PruebaP.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BancoP.Application.Queries.CuentaQueries
{
    public class GetCuentaListExpressionQuery : IRequest<ResponseModel<List<Cuenta>>>
    {
        public Expression<Func<Cuenta, bool>> Path { get; set; }
        public GetCuentaListExpressionQuery(Expression<Func<Cuenta, bool>> path)
        {
            Path = path;
        }
    }
}
