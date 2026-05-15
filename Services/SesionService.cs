using FinancieraConsumo.Web.Models.Entities;

public class SesionService
{
    public Usuario? UsuarioActual { get; set; }

    public bool EstaLogueado => UsuarioActual != null;
    public void CerrarSesion()
    {
        UsuarioActual = null;
    }

}