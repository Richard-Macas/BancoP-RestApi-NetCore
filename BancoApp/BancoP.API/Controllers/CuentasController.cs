using BancoP.Application.Commands.CuentaCommands;
using BancoP.Application.Models.Cuenta;
using BancoP.Application.Queries.CuentaQueries;
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
    public class CuentasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CuentasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCuentas()
        {
            return Ok(await _mediator.Send(new GetCuentaListQuery()));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCuenta(int Id)
        {
            return Ok(await _mediator.Send(new GetCuentaByIdQuery(Id)));
        }

        [HttpPost]
        public async Task<IActionResult> PostCuenta(CuentaInsert cliente)
        {
            return Ok(await _mediator.Send(new InsertCuentaCommand(cliente)));
        }

        [HttpPut]
        public async Task<IActionResult> PutCuenta(CuentaUpdate cliente)
        {
            return Ok(await _mediator.Send(new UpdateCuentaCommand(cliente)));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCuenta(int Id)
        {
            return Ok(await _mediator.Send(new DeleteCuentaCommand(Id)));
        }
    }
}
