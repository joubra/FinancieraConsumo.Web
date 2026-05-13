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
    }
}