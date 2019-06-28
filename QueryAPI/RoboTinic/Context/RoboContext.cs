using Microsoft.EntityFrameworkCore;
using RoboTinic.Configuration;
using RoboTinic.RoboDTO;

namespace RoboTinic.Context
{
    public class RoboContext : DbContext
    {
        private static bool _create = false;
        public RoboContext() : base()
        {
            if (!_create)
            {
                _create = true;
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite(@"Data Source= C:\sqlLite\ROBOBASE.db");

        }

        public DbSet<Material> Material { get; set; }
        public DbSet<Content> Content { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Mensagem> Mensagem { get; set; }
       // public DbSet<Detalhe> Detalhe { get; set; }
        public DbSet<Apresentacao> Apresentacao { get; set; }
        public DbSet<Fabricante> Fabricante { get; set; }
        public DbSet<ClasseRisco> ClasseRisco { get; set; }
        public DbSet<Vencimento> Vencimento { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MaterialConfiguration());
            modelBuilder.ApplyConfiguration(new ContentConfiguration());
            modelBuilder.ApplyConfiguration(new EmpresaConfiguration());
            modelBuilder.ApplyConfiguration(new MensagemConfiguration());

            modelBuilder.ApplyConfiguration(new DetalheConfiguration());
            modelBuilder.ApplyConfiguration(new ApresentacaoConfiguration());
            modelBuilder.ApplyConfiguration(new FabricanteConfiguration());
            modelBuilder.ApplyConfiguration(new ClasseRiscoConfiguration());
            modelBuilder.ApplyConfiguration(new VencimentoConfiguration());

        }
    }
}
