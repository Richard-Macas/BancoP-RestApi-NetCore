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
    public class RepositoryPersona : RepositoryGeneric<Persona, dal.Persona>, IRepositoryPersona
    {

        public RepositoryPersona(BaseDatosContext _context) : base(_context)
        {
        }
    }
}
