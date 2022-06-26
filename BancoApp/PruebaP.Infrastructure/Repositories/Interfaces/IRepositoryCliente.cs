using PruebaP.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PruebaP.Infrastructure.Repositories.Interfaces
{
    public interface IRepositoryCliente
    {
        Task<Cliente> GetAsync(Expression<Func<Cliente, bool>> path);
        Task<Cliente> GetAsync(int id);
        Task<List<Cliente>> GetAllAsync(Expression<Func<Cliente, bool>> path);
        Task<List<Cliente>> GetAllAsync();
        Task<Cliente> AddAsync(Cliente entity);
        Task<Cliente> UpdateAsync(Cliente entity);
        Task<Cliente> DeleteAsync(int id);
    }
}
