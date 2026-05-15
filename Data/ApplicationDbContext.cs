using Microsoft.EntityFrameworkCore;
using FinancieraConsumo.Web.Models.Entities;

namespace FinancieraConsumo.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Fiador> Fiadores { get; set; }
        public DbSet<SolicitudCredito> SolicitudesCredito { get; set; }
        public DbSet<Credito> Creditos { get; set; }
        public DbSet<Cuota> Cuotas { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<PagoDetalle> PagosDetalle { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
    }
}