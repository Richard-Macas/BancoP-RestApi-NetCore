using BancoP.Application.Models;
using MediatR;
using PruebaP.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoP.Application.Queries.CuentaQueries
{
    public class GetCuentaListQuery : IRequest<ResponseModel<List<Cuenta>>>
    {

    }
}
