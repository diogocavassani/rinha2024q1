using Microsoft.EntityFrameworkCore;
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
        public DbSet<RetornoAtualizarSaldo> AtualizarSaldos => Set<RetornoAtualizarSaldo>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transacao>()
             .HasOne(t => t.Cliente)
             .WithMany(c => c.Transacoes)
             .HasForeignKey(t => t.IdCliente);

            modelBuilder.Entity<RetornoAtualizarSaldo>().HasNoKey();
            base.OnModelCreating(modelBuilder);
        }
    }
}
