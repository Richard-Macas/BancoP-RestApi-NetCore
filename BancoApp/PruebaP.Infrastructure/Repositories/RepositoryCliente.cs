using AutoMapper;
using PruebaP.Domain.Data;
using PruebaP.Infrastructure.Mapper.MapperProfile;
using PruebaP.Infrastructure.Models;
using PruebaP.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using dal = PruebaP.Domain.Entities;

namespace PruebaP.Infrastructure.Repositories
{
    public class RepositoryCliente : RepositoryGeneric<Cliente, dal.Cliente>, IRepositoryCliente
    {

        public RepositoryCliente(BaseDatosContext _context) : base(_context)
        {
        }
    }
}
