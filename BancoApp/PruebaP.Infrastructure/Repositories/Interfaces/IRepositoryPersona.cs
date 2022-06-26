using PruebaP.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PruebaP.Infrastructure.Repositories.Interfaces
{
    public interface IRepositoryPersona
    {
        Task<Persona> GetAsync(Expression<Func<Persona, bool>> path);
        Task<Persona> GetAsync(int id);
        Task<List<Persona>> GetAllAsync(Expression<Func<Persona, bool>> path);
        Task<List<Persona>> GetAllAsync();
        Task<Persona> AddAsync(Persona entity);
        Task<Persona> UpdateAsync(Persona entity);
        Task<Persona> DeleteAsync(int id);
    }
}
