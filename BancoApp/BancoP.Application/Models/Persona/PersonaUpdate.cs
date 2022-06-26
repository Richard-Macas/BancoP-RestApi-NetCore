using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BancoP.Application.Models.Persona
{
    public class PersonaUpdate
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public int? Edad { get; set; }
        public string Identificacion { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public class PersonaUpdateValidation : AbstractValidator<PersonaUpdate>
        {
            public PersonaUpdateValidation()
            {
                RuleFor(x => x.Id).GreaterThan(0);
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Direccion).NotEmpty();
                RuleFor(x => x.Telefono).NotEmpty();
            }
        }
    }
}
