using BancoP.Application.Models.Persona;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoP.Application.Models.Cliente
{
    public class ClienteInsert : PersonaInsert
    {
        public string ClienteId { get; set; }
        public string Contrasena { get; set; }
        public bool Estado { get; set; }

        public class ClienteInsertValidation : AbstractValidator<ClienteInsert>
        {
            public ClienteInsertValidation()
            {
                RuleFor(x => x.ClienteId).NotEmpty();
                RuleFor(x => x.Contrasena).NotEmpty();
                RuleFor(x => x.Estado).NotEmpty();
                
                // Validator Herencia Persona
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Edad).GreaterThan(0);
                RuleFor(x => x.Identificacion).NotEmpty();
                RuleFor(x => x.Direccion).NotEmpty();
                RuleFor(x => x.Telefono).NotEmpty();
            }
        }
    }
}
