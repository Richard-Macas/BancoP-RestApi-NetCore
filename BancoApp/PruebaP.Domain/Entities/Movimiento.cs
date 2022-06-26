using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PruebaP.Domain.Entities
{
    public class Movimiento
    {
        public int Id { get; set; }
        public int? IdCuenta { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoMovimiento { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
        public virtual Cuenta IdCuentaNavigation { get; set; }
    }
}
