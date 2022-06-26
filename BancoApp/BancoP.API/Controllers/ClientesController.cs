using BancoP.Application.Commands.ClienteCommands;
using BancoP.Application.Models.Cliente;
using BancoP.Application.Queries.ClienteQueries;
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
    public class ClientesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            return Ok(await _mediator.Send(new GetClienteListQuery()));
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCliente(int Id)
        {
            return Ok(await _mediator.Send(new GetClienteByIdQuery(Id)));
        }

        [HttpPost]
        public async Task<IActionResult> PostCliente(ClienteInsert cliente)
        {
            return Ok(await _mediator.Send(new InsertClienteCommand(cliente)));
        }

        [HttpPut]
        public async Task<IActionResult> PutCliente(ClienteUpdate cliente)
        {
            return Ok(await _mediator.Send(new UpdateClienteCommand(cliente)));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCliente(int Id)
        {
            return Ok(await _mediator.Send(new DeleteClienteCommand(Id)));
        }
    }
}
