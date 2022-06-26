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
    public class GetMovimientoByIdHandler : IRequestHandler<GetMovimientoByIdQuery, ResponseModel<Movimiento>>
    {
        private readonly IRepositoryMovimiento _Movimiento;

        public GetMovimientoByIdHandler(IRepositoryMovimiento Movimiento)
        {
            _Movimiento = Movimiento;
        }

        public async Task<ResponseModel<Movimiento>> Handle(GetMovimientoByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _Movimiento.GetAsync(request.Id);

                if(data == null)
                    return new ResponseModel<Movimiento>(false, $"Error GMBIH_01. No hay un registro con Id: {request.Id}", data);

                return new ResponseModel<Movimiento>(true, "", data);
            }
            catch (Exception ex)
            {
                return new ResponseModel<Movimiento>(false, $"Error GMBIH_02. {ex.Message}", null);
            }
        }
    }
}
