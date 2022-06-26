using PruebaP.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PruebaP.Infrastructure.Repositories.Interfaces
{
    public interface IRepositoryCuenta
    {
        Task<Cuenta> GetAsync(Expression<Func<Cuenta, bool>> path);
        Task<Cuenta> GetAsync(int id);
        Task<Cuenta> GetWithMovimientosAsync(int id);
        Task<List<Cuenta>> GetAllAsync(Expression<Func<Cuenta, bool>> path);
        Task<List<Cuenta>> GetAllWithMovimientosAsync(Expression<Func<Cuenta, bool>> path);
        Task<List<Cuenta>> GetAllAsync();
        Task<Cuenta> AddAsync(Cuenta entity);
        Task<Cuenta> UpdateAsync(Cuenta entity);
        Task<Cuenta> DeleteAsync(int id);
    }
}
