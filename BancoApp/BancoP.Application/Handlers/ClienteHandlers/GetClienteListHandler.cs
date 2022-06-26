using BancoP.Application.Models;
using BancoP.Application.Queries.ClienteQueries;
using MediatR;
using PruebaP.Infrastructure.Models;
using PruebaP.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BancoP.Application.Handlers.ClienteHandlers
{
    public class GetClienteListHandler : IRequestHandler<GetClienteListQuery, ResponseModel<List<Cliente>>>
    {
        private readonly IRepositoryCliente _Cliente;

        public GetClienteListHandler(IRepositoryCliente Cliente)
        {
            _Cliente = Cliente;
        }

        public async Task<ResponseModel<List<Cliente>>> Handle(GetClienteListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _Cliente.GetAllAsync();
                return new ResponseModel<List<Cliente>>(true, "", data);
            }
            catch (Exception ex)
            {
                return new ResponseModel<List<Cliente>>(false, $"Error GCLH_01. {ex.Message}", null);
            }

        }
    }
}
