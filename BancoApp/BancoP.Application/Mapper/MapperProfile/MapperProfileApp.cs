using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using BancoP.Application.Models.Cliente;
using System;
using System.Collections.Generic;
using System.Text;
using dto = PruebaP.Infrastructure.Models;
using dal = PruebaP.Domain.Entities;
using BancoP.Application.Models.Cuenta;
using BancoP.Application.Models.Movimiento;

namespace BancoP.Application.Mapper.MapperProfile
{
    public class MapperProfileApp : Profile
    {
        public static MapperConfiguration configuracionMapper = new MapperConfiguration(cfg =>
        {
            cfg.AddExpressionMapping();

            // Entities map
            cfg.CreateMap<dto.Cliente, ClienteInsert>().ReverseMap();
            cfg.CreateMap<dto.Cliente, ClienteUpdate>().ReverseMap();

            cfg.CreateMap<dto.Cuenta, CuentaInsert>().ReverseMap();
            cfg.CreateMap<dto.Cuenta, CuentaUpdate>().ReverseMap();

            cfg.CreateMap<dto.Movimiento, MovimientoInsert>().ReverseMap();


        });
    }
}
