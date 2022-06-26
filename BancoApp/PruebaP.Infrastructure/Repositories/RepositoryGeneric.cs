using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.EntityFrameworkCore;
using PruebaP.Domain.Data;
using PruebaP.Infrastructure.Mapper.MapperProfile;
using PruebaP.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PruebaP.Infrastructure
{
    public class RepositoryGeneric<TEntidadBle, TEntidadDal> : IDisposable, IRepositoryGeneric<TEntidadBle, TEntidadDal> where TEntidadBle : class where TEntidadDal : class
    {
        private readonly BaseDatosContext context;
        private readonly IMapper _mapper;

        public RepositoryGeneric(BaseDatosContext _context)
        {
            _mapper = MapperProfile.configuracionMapper.CreateMapper();
            context = _context;
        }

        public async Task<TEntidadBle> GetAsync(Expression<Func<TEntidadBle, bool>> path)
        {
            Expression<Func<TEntidadDal, bool>> expresionDAL = _mapper.MapExpression<Expression<Func<TEntidadDal, bool>>>(path);
            TEntidadDal entidadDal = (await context.Set<TEntidadDal>().Where(expresionDAL).ToListAsync()).FirstOrDefault();

            if (entidadDal != null)
                context.Entry(entidadDal).State = EntityState.Detached;

            TEntidadBle entidadBll = entidadDal == null ? null : _mapper.Map<TEntidadBle>(entidadDal);
            return entidadBll;
        }

        public async Task<TEntidadBle> GetAsync(int id)
        {
            TEntidadDal entidadDal = await context.Set<TEntidadDal>().FindAsync(id);

            if (entidadDal != null)
                context.Entry(entidadDal).State = EntityState.Detached;

            TEntidadBle entidadBll = entidadDal == null ? null : _mapper.Map<TEntidadBle>(entidadDal);
            return entidadBll;
        }

        public async Task<List<TEntidadBle>> GetAllAsync(Expression<Func<TEntidadBle, bool>> path)
        {
            Expression<Func<TEntidadDal, bool>> expresionDAL = _mapper.MapExpression<Expression<Func<TEntidadDal, bool>>>(path);
            List<TEntidadDal> entidadDal = await context.Set<TEntidadDal>().Where(expresionDAL).Take(10).ToListAsync();

            List<TEntidadBle> entidadBll = entidadDal.Select(i => _mapper.Map<TEntidadBle>(i)).ToList();
            return entidadBll;
        }

        public async Task<List<TEntidadBle>> GetAllAsync()
        {
            List<TEntidadDal> entidadDal = await context.Set<TEntidadDal>().ToListAsync();

            List<TEntidadBle> entidadBll = entidadDal.Select(i => _mapper.Map<TEntidadBle>(i)).ToList();
            return entidadBll;
        }

        public async Task<TEntidadBle> AddAsync(TEntidadBle entity)
        {
                TEntidadDal claseDal = _mapper.Map<TEntidadDal>(entity);
                var entidadDalInsertada = context.Set<TEntidadDal>().Add(claseDal);
                await context.SaveChangesAsync();
                TEntidadBle entidadBleRetorno = _mapper.Map<TEntidadBle>(entidadDalInsertada.Entity);

                return entidadBleRetorno;

        }

        public async Task<TEntidadBle> UpdateAsync(TEntidadBle entity)
        {
                TEntidadDal claseDal = _mapper.Map<TEntidadDal>(entity);
                context.Entry(claseDal).State = EntityState.Modified;
                TEntidadBle entidadBleRetorno = _mapper.Map<TEntidadBle>(claseDal);
                await context.SaveChangesAsync();
                return entidadBleRetorno;

        }

        public async Task<TEntidadBle> DeleteAsync(int id)
        {
            
                TEntidadDal claseDal = context.Set<TEntidadDal>().Find(id);
                var entidadDalEliminada = context.Set<TEntidadDal>().Remove(claseDal);
                TEntidadBle entidadBleRetorno = _mapper.Map<TEntidadBle>(entidadDalEliminada.Entity);
                await context.SaveChangesAsync();
                return entidadBleRetorno;

        }


        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
