using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.EntityFrameworkCore;
using PruebaP.Domain.Data;
using PruebaP.Infrastructure.Mapper.MapperProfile;
using PruebaP.Infrastructure.Models;
using PruebaP.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using dal = PruebaP.Domain.Entities;

namespace PruebaP.Infrastructure.Repositories
{
    public class RepositoryMovimiento : RepositoryGeneric<Movimiento, dal.Movimiento>, IRepositoryMovimiento
    {

        private readonly BaseDatosContext context;
        private readonly IMapper _mapper;

        public RepositoryMovimiento(BaseDatosContext _context) : base(_context)
        {
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
            context = _context;
        }

        public async Task<List<Movimiento>> GetAllCuentaAndClienteAsync(Expression<Func<Movimiento, bool>> path)
        {
            var pathDal = _mapper.MapExpression<Expression<Func<dal.Movimiento, bool>>>(path);
            List<dal.Movimiento> movimiento = await context.Set<dal.Movimiento>().Where(pathDal)
                .Include(c => c.IdCuentaNavigation)
                .ThenInclude(x => x.IdClienteNavigation)
                .ToListAsync();

            List<Movimiento> movimientoMap = movimiento.Select(i => _mapper.Map<Movimiento>(i)).ToList();
            return movimientoMap;
        }
    }
}
