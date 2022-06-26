using BancoP.Application.Models;
using MediatR;
using PruebaP.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoP.Application.Queries.ClienteQueries
{
    public class GetClienteListQuery : IRequest<ResponseModel<List<Cliente>>>
    {

    }
}
