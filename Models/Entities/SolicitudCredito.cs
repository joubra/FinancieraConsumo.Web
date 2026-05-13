using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Solicitud_Credito")]
public class SolicitudCredito
{
    [Key]
    public int IdSolicitud { get; set; }

    public int IdCliente { get; set; }
    public int? IdFiador { get; set; }

    public decimal MontoSolicitado { get; set; }
    public int PlazoMeses { get; set; }

    public int IdAnalista { get; set; }

    public DateTime FechaSolicitud { get; set; } = DateTime.Now;

    public string EstadoSolicitud { get; set; } = "Pendiente";
}