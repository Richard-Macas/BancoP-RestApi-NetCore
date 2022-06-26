using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PruebaP.Infrastructure.Repositories.Interfaces
{
    public interface IRepositoryGeneric<TEntidadBle, TEntidadDal> where TEntidadBle : class where TEntidadDal : class
    {
        Task<TEntidadBle> GetAsync(Expression<Func<TEntidadBle, bool>> path);
        Task<TEntidadBle> GetAsync(int id);
        Task<List<TEntidadBle>> GetAllAsync(Expression<Func<TEntidadBle, bool>> path);
        Task<List<TEntidadBle>> GetAllAsync();
        Task<TEntidadBle> AddAsync(TEntidadBle entity);
        Task<TEntidadBle> UpdateAsync(TEntidadBle entity);
        Task<TEntidadBle> DeleteAsync(int id);

    }
}
