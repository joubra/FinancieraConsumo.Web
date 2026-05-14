using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancieraConsumo.Web.Models.Entities
{
    [Table("Cuota")]
    public class Cuota
    {
        [Key]
        public int IdCuota { get; set; }

        public int IdCredito { get; set; }

        public int NumeroCuota { get; set; }

        public decimal Capital { get; set; }

        public decimal Interes { get; set; }

        public decimal MoraAcumulada { get; set; } = 0;

        public DateTime FechaVencimiento { get; set; }

        public string EstadoCuota { get; set; } = "Pendiente";
    }
}