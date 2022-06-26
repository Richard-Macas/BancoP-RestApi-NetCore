using AutoMapper;
using BancoP.Application.Commands.MovimientoCommands;
using BancoP.Application.Mapper.MapperProfile;
using BancoP.Application.Models;
using BancoP.Application.Queries.CuentaQueries;
using MediatR;
using PruebaP.Infrastructure.Models;
using PruebaP.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BancoP.Application.Handlers.MovimientoHandlers
{
    public class InsertMovimientoHandler : IRequestHandler<InsertMovimientoCommand, ResponseModel<Movimiento>>
    {
        private readonly IRepositoryMovimiento _movimiento;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public InsertMovimientoHandler(IRepositoryMovimiento movimiento, IMediator mediator)
        {
            _movimiento = movimiento;
            _mapper = MapperProfileApp.configuracionMapper.CreateMapper();
            _mediator = mediator;
        }

        public async Task<ResponseModel<Movimiento>> Handle(InsertMovimientoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Se obtiene el saldo actual
                var cuentaTransaccionData = await _mediator.Send(new GetCuentaMovimientosByIdQuery((int)request.Movimiento.IdCuenta));

                // En caso de error en la consulta de la cuenta
                if(!cuentaTransaccionData.Success)
                    return new ResponseModel<Movimiento>(false, $"{cuentaTransaccionData.Message}", null);

                // Se obtiene el saldo inicial de la cuenta
                var saldoInicial = cuentaTransaccionData.Result.SaldoInicial;

                // Se obtiene el último movimiento de la cuenta
                var movimientosAnteriores = cuentaTransaccionData.Result.Movimientos.OrderBy(x => x.Id).ToList();
                
                // Inicializamos el saldo disponible del último movimiento
                decimal saldoDisponibleUltimoMovimiento = 0;

                // En caso de que no existan movimientos anteriores
                if (movimientosAnteriores.Count == 0)
                    saldoDisponibleUltimoMovimiento = saldoInicial;
                else // En caso de que ya existan movimientos anteriores, se obtiene el saldo disponible del último movimiento
                    saldoDisponibleUltimoMovimiento = movimientosAnteriores[^1].Saldo;

                // Inicializamos el saldo disponible del movimiento actual
                decimal saldoDisponibleMovimientoActual = 0;

                // Inicializamos el saldo límite de $1000
                var valorLimiteDiario = 1000;

                // Validar si es depósito o retiro
                if (request.EsDeposito)
                    saldoDisponibleMovimientoActual = saldoDisponibleUltimoMovimiento + request.Movimiento.Valor;
                else
                {
                    // En caso de que el saldo disponible del último movimiento sea igual a 0
                    if (saldoDisponibleUltimoMovimiento <= 0)
                        return new ResponseModel<Movimiento>(false, $"Saldo no disponible", null);

                    // En caso de que el valor sobrepase el saldo último disponible
                    if((saldoDisponibleUltimoMovimiento - request.Movimiento.Valor) < 0)
                        return new ResponseModel<Movimiento>(false, $"El valor sobrepasa su saldo disponible", null);

                    // Se obtiene todos los movimientos de tipo retiro realizados el día actual
                    var movimientoRetirosDiaActual = movimientosAnteriores.FindAll(x => x.Fecha.Date.Equals(DateTime.Now.Date) && x.TipoMovimiento.Equals("Retiro"));

                    // Solo en caso de que existan más retiros el día actual
                    if(movimientoRetirosDiaActual.Count > 0)
                    {
                        var sumaValoresRetirosAnteriores = movimientoRetirosDiaActual.Select(x => x.Valor).Sum();

                        if((sumaValoresRetirosAnteriores + request.Movimiento.Valor) > valorLimiteDiario)
                            return new ResponseModel<Movimiento>(false, $"Cupo diario excedido", null);
                    } else if(request.Movimiento.Valor > valorLimiteDiario)
                        return new ResponseModel<Movimiento>(false, $"Cupo diario excedido", null);


                    saldoDisponibleMovimientoActual = saldoDisponibleUltimoMovimiento - request.Movimiento.Valor;
                }

                var movimientoDto = _mapper.Map<Movimiento>(request.Movimiento);

                // Se asigna el saldo disponible final
                movimientoDto.Saldo = saldoDisponibleMovimientoActual;

                // Se asigna el tipo de cuenta 
                movimientoDto.TipoMovimiento = request.EsDeposito ? "Depósito" : "Retiro";

                var data = await _movimiento.AddAsync(movimientoDto);
                return new ResponseModel<Movimiento>(true, "", data);
            }
            catch (Exception ex)
            {
                return new ResponseModel<Movimiento>(false, $"Error IMH_01. {ex.Message}", null);
            }
        }
    }
}
