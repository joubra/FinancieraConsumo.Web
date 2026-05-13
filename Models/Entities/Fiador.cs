using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancieraConsumo.Web.Models.Entities
{
    [Table("Fiador")]
    public class Fiador
    {
        [Key]
        public int IdFiador { get; set; }

        [Required]
        public string DocumentoIdentidad { get; set; } = string.Empty;

        [Required]
        public string Nombres { get; set; } = string.Empty;

        [Required]
        public string Apellidos { get; set; } = string.Empty;

        [Required]
        public string TelefonoCelular { get; set; } = string.Empty;

        [Required]
        public string DireccionDomicilio { get; set; } = string.Empty;

        public decimal IngresoMensual { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;
    }
}