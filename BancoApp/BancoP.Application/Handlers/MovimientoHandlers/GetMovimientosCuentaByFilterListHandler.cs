using BancoP.Application.Models;
using BancoP.Application.Models.Movimiento;
using BancoP.Application.Queries.CuentaQueries;
using BancoP.Application.Queries.MovimientoQueries;
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
    public class GetMovimientosCuentaByFilterListHandler : IRequestHandler<GetMovimientosCuentaByFilterListQuery, ResponseModel<List<MovimientoReport>>>
    {
        private readonly IRepositoryMovimiento _Movimiento;
        private readonly IMediator _mediator;

        public GetMovimientosCuentaByFilterListHandler(IRepositoryMovimiento Movimiento, IMediator mediator)
        {
            _Movimiento = Movimiento;
            _mediator = mediator;
        }

        public async Task<ResponseModel<List<MovimientoReport>>> Handle(GetMovimientosCuentaByFilterListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                // En caso de que no se ingresen fechas e Id
                if(request.From == null || request.To == null || request.Id <= 0)
                    return new ResponseModel<List<MovimientoReport>>(false, $"Error GMCBFLH_01. From, To e Id son campos obligatorios", null);

                // Se obtiene los movimientos del cliente en el rango de fechas establecido
                var movimientosClienteData = await _mediator.Send(new
                    GetMovimientoListExpressionQuery(x => x.IdCuentaNavigation.IdCliente == request.Id
                    && x.Fecha.Date >= request.From.Date
                    && x.Fecha.Date <= request.To.Date
                    ));

                // En caso de error en la consulta
                if (!movimientosClienteData.Success)
                    return new ResponseModel<List<MovimientoReport>>(false, $"{movimientosClienteData.Message}", null);

                // Se tranforma a la estructura de reporte
                var listaMovimientos = movimientosClienteData.Result.OrderByDescending(x => x.Fecha).Select(m =>
                {
                    return new MovimientoReport()
                    {
                        Fecha = m.Fecha.ToString("dd/MM/yyyy"),
                        Cliente = m.IdCuentaNavigation.IdClienteNavigation.Nombre,
                        NumeroCuenta = m.IdCuentaNavigation.NumeroCuenta,
                        Tipo = m.IdCuentaNavigation.TipoCuenta,
                        SaldoInicial = m.IdCuentaNavigation.SaldoInicial,
                        Estado = m.IdCuentaNavigation.Estado,
                        Movimiento = m.TipoMovimiento.Equals("Retiro") ? (m.Valor * (-1)) : m.Valor,
                        SaldoDisponible = m.Saldo
                    };
                }).ToList();

                return new ResponseModel<List<MovimientoReport>>(true, "", listaMovimientos);
            }
            catch (Exception ex)
            {
                return new ResponseModel<List<MovimientoReport>>(false, $"Error GMCBFLH_02. {ex.Message}", null);
            }

        }
    }
}
