using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancieraConsumo.Web.Models.Entities
{
    [Table("Credito")]
    public class Credito
    {
        [Key]
        public int IdCredito { get; set; }

        public int IdSolicitud { get; set; }

        public decimal MontoOtorgado { get; set; }

        public decimal TasaInteresAnual { get; set; }

        public int PlazoMeses { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public string EstadoCredito { get; set; } = "Vigente";
    }
}