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
    public class DeleteMovimientoHandler : IRequestHandler<DeleteMovimientoCommand, ResponseModel<Movimiento>>
    {
        private readonly IRepositoryMovimiento _movimiento;

        public DeleteMovimientoHandler(IRepositoryMovimiento movimiento)
        {
            _movimiento = movimiento;
        }

        public async Task<ResponseModel<Movimiento>> Handle(DeleteMovimientoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var ValidId = await _movimiento.GetAsync(request.Id);

                if (ValidId == null)
                    return new ResponseModel<Movimiento>(false, $"Error DMH_01. No un registro con Id: {request.Id}", null);

                var data = await _movimiento.DeleteAsync(request.Id);
                return new ResponseModel<Movimiento>(true, "", data);
            }
            catch (Exception ex)
            {
                return new ResponseModel<Movimiento>(false, $"Error DMH_02. {ex.Message}", null);
            }
        }
    }
}
