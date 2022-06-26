using BancoP.Application.Commands.MovimientoCommands;
using BancoP.Application.Models.Movimiento;
using BancoP.Application.Queries.MovimientoQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaP.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovimientosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovimientos()
        {
            return Ok(await _mediator.Send(new GetMovimientoListQuery()));
        }

        [HttpGet]
        [Route("PorClienteFechas")]
        public async Task<IActionResult> GetCuentas(DateTime From, DateTime To, int IdCliente)
        {
            return Ok(await _mediator.Send(new GetMovimientosCuentaByFilterListQuery(From, To, IdCliente)));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetMovimiento(int Id)
        {
            return Ok(await _mediator.Send(new GetMovimientoByIdQuery(Id)));
        }

        [HttpPost]
        [Route("Deposito")]
        public async Task<IActionResult> PostDepositoMovimiento(MovimientoInsert cliente)
        {
            return Ok(await _mediator.Send(new InsertMovimientoCommand(cliente, true)));
        }

        [HttpPost]
        [Route("Retiro")]
        public async Task<IActionResult> PostRetiroMovimiento(MovimientoInsert cliente)
        {
            return Ok(await _mediator.Send(new InsertMovimientoCommand(cliente, false)));
        }

        [HttpPut]
        public async Task<IActionResult> PutMovimiento(Movimiento cliente)
        {
            return Ok(await _mediator.Send(new UpdateMovimientoCommand(cliente)));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteMovimiento(int Id)
        {
            return Ok(await _mediator.Send(new DeleteMovimientoCommand(Id)));
        }
    }
}
