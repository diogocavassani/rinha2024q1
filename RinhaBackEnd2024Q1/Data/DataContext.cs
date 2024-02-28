using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RinhaBackEnd2024Q1.Model;

namespace RinhaBackEnd2024Q1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Transacao> Tracacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasMany(t => t.Transacoes)
                .WithOne(c => c.Cliente)
                .HasForeignKey(t => t.IdCliente);
            base.OnModelCreating(modelBuilder);
        }
    }
}
