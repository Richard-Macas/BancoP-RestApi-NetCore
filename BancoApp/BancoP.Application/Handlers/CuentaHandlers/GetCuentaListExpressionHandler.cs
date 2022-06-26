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
    public class GetCuentaListExpressionHandler : IRequestHandler<GetCuentaListExpressionQuery, ResponseModel<List<Cuenta>>>
    {
        private readonly IRepositoryCuenta _cuenta;

        public GetCuentaListExpressionHandler(IRepositoryCuenta cuenta)
        {
            _cuenta = cuenta;
        }

        public async Task<ResponseModel<List<Cuenta>>> Handle(GetCuentaListExpressionQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _cuenta.GetAllWithMovimientosAsync(request.Path);
                return new ResponseModel<List<Cuenta>>(true, "", data);
            }
            catch (Exception ex)
            {
                return new ResponseModel<List<Cuenta>>(false, $"Error URLEH_01. {ex.Message}", null);
            }

        }
    }
}
