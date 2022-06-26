using PruebaP.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PruebaP.Infrastructure.Repositories.Interfaces
{
    public interface IRepositoryMovimiento
    {
        Task<Movimiento> GetAsync(Expression<Func<Movimiento, bool>> path);
        Task<Movimiento> GetAsync(int id);
        Task<List<Movimiento>> GetAllAsync(Expression<Func<Movimiento, bool>> path); 
        Task<List<Movimiento>> GetAllCuentaAndClienteAsync(Expression<Func<Movimiento, bool>> path);
        Task<List<Movimiento>> GetAllAsync();
        Task<Movimiento> AddAsync(Movimiento entity);
        Task<Movimiento> UpdateAsync(Movimiento entity);
        Task<Movimiento> DeleteAsync(int id);
    }
}
