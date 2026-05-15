using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("PagoDetalle")]
public class PagoDetalle
{
    [Key]
    public int IdPagoDetalle { get; set; }

    public int IdPago { get; set; }
    public int IdCuota { get; set; }

    public decimal MontoAplicado { get; set; }
}