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
    public class GetClienteByIdHandler : IRequestHandler<GetClienteByIdQuery, ResponseModel<Cliente>>
    {
        private readonly IRepositoryCliente _Cliente;

        public GetClienteByIdHandler(IRepositoryCliente Cliente)
        {
            _Cliente = Cliente;
        }

        public async Task<ResponseModel<Cliente>> Handle(GetClienteByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _Cliente.GetAsync(request.Id);

                if(data == null)
                    return new ResponseModel<Cliente>(false, $"Error GCBIH_01. No hay un registro con Id: {request.Id}", data);

                return new ResponseModel<Cliente>(true, "", data);
            }
            catch (Exception ex)
            {
                return new ResponseModel<Cliente>(false, $"Error GCBIH_02. {ex.Message}", null);
            }
        }
    }
}
