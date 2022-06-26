using AutoMapper;
using BancoP.Application.Commands.CuentaCommands;
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

namespace BancoP.Application.Handlers.CuentaHandlers
{
    public class UpdateCuentaHandler : IRequestHandler<UpdateCuentaCommand, ResponseModel<Cuenta>>
    {
        private readonly IRepositoryCuenta _cuenta;
        private readonly IMapper _mapper;

        public UpdateCuentaHandler(IRepositoryCuenta cuenta)
        {
            _cuenta = cuenta;
            _mapper = MapperProfileApp.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseModel<Cuenta>> Handle(UpdateCuentaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var ValidId = await _cuenta.GetAsync(request.Cuenta.Id);

                if (ValidId == null)
                    return new ResponseModel<Cuenta>(false, $"Error UCUH_01. No hay un registro con Id: {request.Cuenta.Id}", null);

                var cuentaDto = _mapper.Map<Cuenta>(request.Cuenta);
                var data = await _cuenta.UpdateAsync(cuentaDto);
                return new ResponseModel<Cuenta>(true, "", data);
            }
            catch (Exception ex)
            {
                return new ResponseModel<Cuenta>(false, $"Error UCUH_02. {ex.Message}", null);
            }
        }
    }
}
