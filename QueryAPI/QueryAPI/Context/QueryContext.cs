using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueryAPI.DTO;
using QueryAPI.DTO.MatDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConData.Context
{
    public class QueryContext : DbContext
    {
        private static bool _create = false;
        public QueryContext() : base()
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
            optionsBuilder.UseSqlite(@"Data Source= C:\sqlLite\SUPORTE.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ContentMaterialConfiguration());
            //modelBuilder.ApplyConfiguration(new ContentMaterialClasseRiscoConfiguration());
            //modelBuilder.ApplyConfiguration(new ContentMaterialFabricanteConfiguration());
            //modelBuilder.ApplyConfiguration(new EmpresaConfiguration());
            //modelBuilder.ApplyConfiguration(new MaterialConfiguration());
            //modelBuilder.ApplyConfiguration(new VencimentoConfiguration());
            //modelBuilder.ApplyConfiguration(new ApresentacaoMaterialConfiguration());
            //modelBuilder.ApplyConfiguration(new ClasseRiscoConfiguration());
            //modelBuilder.ApplyConfiguration(new FabricanteConfiguration());

        }

        public DbSet<MaterialDTO> Material { get; set; }
        public DbSet<ContentMaterialDTO> Content{ get; set; }
        public DbSet<EmpresaDTO> Empresa { get; set; }
        public DbSet<ApresentacaoMaterial> Apresentacao { get; set; }
        public DbSet<Fabricantes> Fabricante { get; set; }
        public DbSet<ClasseRisco> ClasseRisco { get; set; }
        public DbSet<Vencimento> Vencimento { get; set; }
        // public DbSet<ApresentacaoMaterial> ApresentacaoMaterial { get; set; }
        // public DbSet<ClasseRisco> ClasseRisco { get; set; }
        // public DbSet<ContentClasseRisco> ContentClasseRisco { get; set; }
        // public DbSet<ContentMaterial> ContentMaterial { get; set; }
        // public DbSet<ContentMaterialFabricante> ContentMaterialFabricante { get; set; }
        // public DbSet<Fabricante> Fabricante { get; set; }
        // public DbSet<Material> Material { get; set; }
        ////public DbSet<Produto> Produto { get; set; }
        // public DbSet<Vencimento> Vencimento { get; set; }

    }

}
