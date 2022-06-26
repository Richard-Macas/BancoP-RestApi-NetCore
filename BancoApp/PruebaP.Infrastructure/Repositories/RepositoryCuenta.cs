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
    public class RepositoryCuenta : RepositoryGeneric<Cuenta, dal.Cuenta>, IRepositoryCuenta
    {
        private readonly BaseDatosContext context;
        private readonly IMapper _mapper;

        public RepositoryCuenta(BaseDatosContext _context) : base(_context)
        {
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
            context = _context;
        }

        public async Task<Cuenta> GetWithMovimientosAsync(int id)
        {
            dal.Cuenta entidadDal = await context.Set<dal.Cuenta>().Where(x => x.Id == id)
                .Include(x => x.Movimientos).FirstOrDefaultAsync();

            if (entidadDal != null)
                context.Entry(entidadDal).State = EntityState.Detached;

            Cuenta entidadBll = entidadDal == null ? null : _mapper.Map<Cuenta>(entidadDal);
            return entidadBll;
        }

        public async Task<List<Cuenta>> GetAllWithMovimientosAsync(Expression<Func<Cuenta, bool>> path)
        {
            var pathDal = _mapper.MapExpression<Expression<Func<dal.Cuenta, bool>>>(path);
            List<dal.Cuenta> cuenta = await context.Set<dal.Cuenta>().Where(pathDal)
                .Include(c => c.Movimientos)
                .Include(ur => ur.IdClienteNavigation)
                .ToListAsync();

            List<Cuenta> cuentaMap = cuenta.Select(i => _mapper.Map<Cuenta>(i)).ToList();
            return cuentaMap;
        }
    }
}
