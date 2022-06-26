using AutoMapper;
using BancoP.Application.Commands.ClienteCommands;
using BancoP.Application.Mapper.MapperProfile;
using BancoP.Application.Models;
using BancoP.Application.Models.Cliente;
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
    public class InsertClienteHandler : IRequestHandler<InsertClienteCommand, ResponseModel<Cliente>>
    {
        private readonly IRepositoryCliente _cliente;
        private readonly IMapper _mapper;

        public InsertClienteHandler(IRepositoryCliente cliente)
        {
            _cliente = cliente;
            _mapper = MapperProfileApp.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseModel<Cliente>> Handle(InsertClienteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Validar que la cédula no se repita
                var verificarCedula = await _cliente.GetAsync(x => x.Identificacion == request.Cliente.Identificacion);
                
                // En caso de que ya existe un usuario registrado con la misma cédula
                if(verificarCedula != null)
                    return new ResponseModel<Cliente>(false, $"Error ICH_01. Ya existe un registros con el mismo número de identificación", null);

                var clienteDto = _mapper.Map<Cliente>(request.Cliente);
                var data = await _cliente.AddAsync(clienteDto);
                return new ResponseModel<Cliente>(true, "", data);
            }
            catch (Exception ex)
            {
                return new ResponseModel<Cliente>(false, $"Error ICH_02. {ex.Message}", null);
            }
        }
    }
}
