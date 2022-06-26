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
    public class GetCuentaListHandler : IRequestHandler<GetCuentaListQuery, ResponseModel<List<Cuenta>>>
    {
        private readonly IRepositoryCuenta _Cuenta;

        public GetCuentaListHandler(IRepositoryCuenta Cuenta)
        {
            _Cuenta = Cuenta;
        }

        public async Task<ResponseModel<List<Cuenta>>> Handle(GetCuentaListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _Cuenta.GetAllAsync();
                return new ResponseModel<List<Cuenta>>(true, "", data);
            }
            catch (Exception ex)
            {
                return new ResponseModel<List<Cuenta>>(false, $"Error GCULH_01. {ex.Message}", null);
            }

        }
    }
}
