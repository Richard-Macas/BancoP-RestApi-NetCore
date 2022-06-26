using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PruebaP.Infrastructure.Models
{
    public class Cuenta
    {
        public Cuenta()
        {
            Movimientos = new List<Movimiento>();
        }

        public int Id { get; set; }
        public int? IdCliente { get; set; }
        public string NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }

        public Cliente IdClienteNavigation { get; set; }
        public List<Movimiento> Movimientos { get; set; }
    }
}
