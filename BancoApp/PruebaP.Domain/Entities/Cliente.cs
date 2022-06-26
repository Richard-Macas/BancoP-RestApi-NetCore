using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PruebaP.Domain.Entities
{
    public class Cliente: Persona
    {
        public Cliente()
        {
            Cuentas = new HashSet<Cuenta>();
        }

        public string ClienteId { get; set; }
        public string Contrasena { get; set; }
        public bool Estado { get; set; }
        public virtual ICollection<Cuenta> Cuentas { get; set; }
    }
}
