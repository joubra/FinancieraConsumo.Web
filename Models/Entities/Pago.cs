using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Pago")]
public class Pago
{
    [Key]
    public int IdPago { get; set; }

    public int IdCredito { get; set; }
    public int IdUsuarioCajero { get; set; }

    public decimal MontoTotal { get; set; }

    public DateTime FechaPago { get; set; } = DateTime.Now;
}