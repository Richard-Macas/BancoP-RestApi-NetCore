
using BancoP.Application.Commands.MovimientoCommands;
using BancoP.Application.Models;
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
    public class UpdateMovimientoHandler : IRequestHandler<UpdateMovimientoCommand, ResponseModel<Movimiento>>
    {
        private readonly IRepositoryMovimiento _movimiento;

        public UpdateMovimientoHandler(IRepositoryMovimiento movimiento)
        {
            _movimiento = movimiento;
        }

        public async Task<ResponseModel<Movimiento>> Handle(UpdateMovimientoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var ValidId = await _movimiento.GetAsync(request.Movimiento.Id);

                if (ValidId == null)
                    return new ResponseModel<Movimiento>(false, $"Error UMH_01. No hay un registro con Id: {request.Movimiento.Id}", null);

                var data = await _movimiento.UpdateAsync(request.Movimiento);
                return new ResponseModel<Movimiento>(true, "", data);
            }
            catch (Exception ex)
            {
                return new ResponseModel<Movimiento>(false, $"Error UMH_02. {ex.Message}", null);
            }
        }
    }
}
