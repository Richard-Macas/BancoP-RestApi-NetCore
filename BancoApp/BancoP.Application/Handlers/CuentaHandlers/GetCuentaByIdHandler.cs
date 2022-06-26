using BancoP.Application.Models;
using BancoP.Application.Queries.CuentaQueries;
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
    public class GetCuentaByIdHandler : IRequestHandler<GetCuentaByIdQuery, ResponseModel<Cuenta>>
    {
        private readonly IRepositoryCuenta _Cuenta;

        public GetCuentaByIdHandler(IRepositoryCuenta Cuenta)
        {
            _Cuenta = Cuenta;
        }

        public async Task<ResponseModel<Cuenta>> Handle(GetCuentaByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _Cuenta.GetAsync(request.Id);

                if(data == null)
                    return new ResponseModel<Cuenta>(false, $"Error GCUBIH_01. No hay un registro con Id: {request.Id}", data);

                return new ResponseModel<Cuenta>(true, "", data);
            }
            catch (Exception ex)
            {
                return new ResponseModel<Cuenta>(false, $"Error GCUBIH_02. {ex.Message}", null);
            }
        }
    }
}
