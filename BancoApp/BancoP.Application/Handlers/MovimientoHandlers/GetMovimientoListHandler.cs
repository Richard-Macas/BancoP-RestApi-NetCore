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
    public class GetMovimientoListHandler : IRequestHandler<GetMovimientoListQuery, ResponseModel<List<Movimiento>>>
    {
        private readonly IRepositoryMovimiento _Movimiento;

        public GetMovimientoListHandler(IRepositoryMovimiento Movimiento)
        {
            _Movimiento = Movimiento;
        }

        public async Task<ResponseModel<List<Movimiento>>> Handle(GetMovimientoListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _Movimiento.GetAllAsync();
                return new ResponseModel<List<Movimiento>>(true, "", data);
            }
            catch (Exception ex)
            {
                return new ResponseModel<List<Movimiento>>(false, $"Error GMLH_01. {ex.Message}", null);
            }

        }
    }
}
