using BancoP.Application.Commands.ClienteCommands;
using BancoP.Application.Models;
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
    public class DeleteClienteHandler : IRequestHandler<DeleteClienteCommand, ResponseModel<Cliente>>
    {
        private readonly IRepositoryCliente _cliente;

        public DeleteClienteHandler(IRepositoryCliente cliente)
        {
            _cliente = cliente;
        }

        public async Task<ResponseModel<Cliente>> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var ValidId = await _cliente.GetAsync(request.Id);

                if (ValidId == null)
                    return new ResponseModel<Cliente>(false, $"Error DCH_01. No un registro con Id: {request.Id}", null);

                var data = await _cliente.DeleteAsync(request.Id);
                return new ResponseModel<Cliente>(true, "", data);
            }
            catch (Exception ex)
            {
                return new ResponseModel<Cliente>(false, $"Error DCH_02. {ex.Message}", null);
            }
        }
    }
}
