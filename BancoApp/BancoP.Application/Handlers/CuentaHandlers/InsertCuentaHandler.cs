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
    public class InsertCuentaHandler : IRequestHandler<InsertCuentaCommand, ResponseModel<Cuenta>>
    {
        private readonly IRepositoryCuenta _cuenta;
        private readonly IMapper _mapper;

        public InsertCuentaHandler(IRepositoryCuenta cuenta)
        {
            _cuenta = cuenta;
            _mapper = MapperProfileApp.configuracionMapper.CreateMapper();
        }

        public async Task<ResponseModel<Cuenta>> Handle(InsertCuentaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var cuentaDto = _mapper.Map<Cuenta>(request.Cuenta);
                var data = await _cuenta.AddAsync(cuentaDto);
                return new ResponseModel<Cuenta>(true, "", data);
            }
            catch (Exception ex)
            {
                return new ResponseModel<Cuenta>(false, $"Error ICUH_01. {ex.Message}", null);
            }
        }
    }
}
