using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoP.Application.Models.Persona
{
    public class PersonaInsert
    {
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public int? Edad { get; set; }
        public string Identificacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public class PersonaInsertValidation : AbstractValidator<PersonaInsert>
        {
            public PersonaInsertValidation()
            {
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Identificacion).NotEmpty();
                RuleFor(x => x.Direccion).NotEmpty();
                RuleFor(x => x.Telefono).NotEmpty();
            }
        }
    }
}
