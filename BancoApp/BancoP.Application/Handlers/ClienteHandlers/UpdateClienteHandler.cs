using AutoMapper;
using BancoP.Application.Commands.ClienteCommands;
using BancoP.Application.Mapper.MapperProfile;
using BancoP.Application.Models;
using MediatR;
using PruebaP.Infrastructure.Models;
using PruebaP.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BancoP.Application.Handlers.ClienteHandlers
{
    public class UpdateClienteHandler : IRequestHandler<UpdateClienteCommand, ResponseModel<Cliente>>
    {
        private readonly IRepositoryCliente _cliente;
        private readonly IMapper _mapper;

        public UpdateClienteHandler(IRepositoryCliente cliente)
        {
            _cliente = cliente;
            _mapper = MapperProfileApp.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseModel<Cliente>> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var ValidId = await _cliente.GetAsync(request.Cliente.Id);

                if (ValidId == null)
                    return new ResponseModel<Cliente>(false, $"Error UCH_01. No hay un registro con Id: {request.Cliente.Id}", null);
                
                var clienteDto = _mapper.Map<Cliente>(request.Cliente);
                clienteDto.Identificacion = ValidId.Identificacion;
                var data = await _cliente.UpdateAsync(clienteDto);
                return new ResponseModel<Cliente>(true, "", data);
            }
            catch (Exception ex)
            {
                return new ResponseModel<Cliente>(false, $"Error UCH_02. {ex.Message}", null);
            }
        }
    }
}
