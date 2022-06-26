using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PruebaP.Infrastructure.Models
{
    public class Cliente: Persona
    {
        public Cliente()
        {
            Cuentas = new List<Cuenta>();
        }

        public string ClienteId { get; set; }
        public string Contrasena { get; set; }
        public bool Estado { get; set; }
        public List<Cuenta> Cuentas { get; set; }
    }
}
