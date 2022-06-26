using BancoP.Application.Models;
using BancoP.Application.Queries.MovimientoQueries;
using MediatR;
using PruebaP.Infrastructure.Models;
using PruebaP.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BancoP.Application.Handlers.MovimientoHandlers
{
    public class GetMovimientoListExpressionHandler : IRequestHandler<GetMovimientoListExpressionQuery, ResponseModel<List<Movimiento>>>
    {
        private readonly IRepositoryMovimiento _movimiento;

        public GetMovimientoListExpressionHandler(IRepositoryMovimiento movimiento)
        {
            _movimiento = movimiento;
        }

        public async Task<ResponseModel<List<Movimiento>>> Handle(GetMovimientoListExpressionQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _movimiento.GetAllCuentaAndClienteAsync(request.Path);
                return new ResponseModel<List<Movimiento>>(true, "", data);
            }
            catch (Exception ex)
            {
                return new ResponseModel<List<Movimiento>>(false, $"Error URLEH_01. {ex.Message}", null);
            }

        }
    }
}
