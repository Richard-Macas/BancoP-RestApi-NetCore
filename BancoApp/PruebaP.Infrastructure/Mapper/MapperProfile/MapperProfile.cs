using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using dal = PruebaP.Domain.Entities;
using dto = PruebaP.Infrastructure.Models;

namespace PruebaP.Infrastructure.Mapper.MapperProfile
{
    public class MapperProfile : Profile
    {
        public static MapperConfiguration configuracionMapper = new MapperConfiguration(cfg =>
        {
            cfg.AddExpressionMapping();

            // Entities map
            cfg.CreateMap<dto.Cliente, dal.Cliente>().ReverseMap();
            cfg.CreateMap<dto.Persona, dal.Persona>().ReverseMap();
            cfg.CreateMap<dto.Cuenta, dal.Cuenta>().ReverseMap();
            cfg.CreateMap<dto.Movimiento, dal.Movimiento>().ReverseMap();

            // Entities expression map
            cfg.CreateMap<Expression<Func<dto.Cliente, bool>>, Expression<Func<dal.Cliente, bool>>>().ReverseMap();
            cfg.CreateMap<Expression<Func<dto.Persona, bool>>, Expression<Func<dal.Persona, bool>>>().ReverseMap();
            cfg.CreateMap<Expression<Func<dto.Cuenta, bool>>, Expression<Func<dal.Cuenta, bool>>>().ReverseMap();
            cfg.CreateMap<Expression<Func<dto.Movimiento, bool>>, Expression<Func<dal.Movimiento, bool>>>().ReverseMap();
        });
    }
}
