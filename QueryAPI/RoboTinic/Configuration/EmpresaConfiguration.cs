using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoboTinic.RoboDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoboTinic.Configuration
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresa");
            builder.HasKey(e=> e.id).HasName("EMPRESA_ID");

            builder.Property(e => e.cnpj)
                .HasColumnName("CNPJ")
                .HasColumnType("VARCHAR(20)");

            builder.Property(e => e.razaoSocial)
                .HasColumnName("RAZAOSOCIAL")
                .HasColumnType("VARCHAR(4000)");
            
            builder.HasOne(c => c.content)
                .WithOne(e => e.empresa)
                .HasForeignKey<Empresa>(c=> c.contentId)
                .HasConstraintName("FK_CONTENT_EMPRESA");
        }
    }
}
