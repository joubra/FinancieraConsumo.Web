using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancieraConsumo.Web.Models.Entities
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        [Required]
        [StringLength(20)]
        public string DocumentoIdentidad { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Nombres { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Apellidos { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string TelefonoCelular { get; set; } = string.Empty;

        [StringLength(100)]
        public string? CorreoElectronico { get; set; }

        [Required]
        [StringLength(255)]
        public string DireccionDomicilio { get; set; } = string.Empty;

        public decimal IngresoMensual { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        public bool Estado { get; set; } = true;
    }
}