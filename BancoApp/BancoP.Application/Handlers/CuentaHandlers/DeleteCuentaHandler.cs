using BancoP.Application.Commands.CuentaCommands;
using BancoP.Application.Models;
using MediatR;
using PruebaP.Infrastructure.Models;
using PruebaP.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BancoP.Application.Handlers.CuentaHandlers
{
    public class DeleteCuentaHandler : IRequestHandler<DeleteCuentaCommand, ResponseModel<Cuenta>>
    {
        private readonly IRepositoryCuenta _cuenta;

        public DeleteCuentaHandler(IRepositoryCuenta cuenta)
        {
            _cuenta = cuenta;
        }

        public async Task<ResponseModel<Cuenta>> Handle(DeleteCuentaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var ValidId = await _cuenta.GetAsync(request.Id);

                if (ValidId == null)
                    return new ResponseModel<Cuenta>(false, $"Error DCUH_01. No un registro con Id: {request.Id}", null);

                var data = await _cuenta.DeleteAsync(request.Id);
                return new ResponseModel<Cuenta>(true, "", data);
            }
            catch (Exception ex)
            {
                return new ResponseModel<Cuenta>(false, $"Error DCUH_02. {ex.Message}", null);
            }
        }
    }
}
