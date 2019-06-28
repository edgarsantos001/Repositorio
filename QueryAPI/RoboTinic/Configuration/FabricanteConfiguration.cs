using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoboTinic.RoboDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoboTinic.Configuration
{
    public class FabricanteConfiguration : IEntityTypeConfiguration<Fabricante>
    {
        public void Configure(EntityTypeBuilder<Fabricante> builder)
        {
            builder.ToTable("FABRICANTE");
            builder.HasKey(d => d.Id).HasName("FABRICANTE_ID");

            builder.Property(n => n.atividade)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("ATIVIDADE");

            builder.Property(r => r.razaoSocial)
                .HasColumnType("VARCHAR(4000)")
                .HasColumnName("RAZAO_SOCIAL");

            builder.Property(r => r.pais)
                .HasColumnType("VARCHAR(500)")
                .HasColumnName("PAIS");


            builder.Property(r => r.local)
                .HasColumnType("VARCHAR(500)")
                .HasColumnName("LOCAL");


            builder.HasOne(c => c.content)
                   .WithMany(e => e.fabricantes)
                   .HasForeignKey(c => c.contentId)
                   .HasConstraintName("FK_DETALHE_FABRICANTE");

            //builder.HasOne(c => c.detalhe)
            //      .WithMany(e => e.fabricantes)
            //      .HasForeignKey(c => c.detalheId)
            //      .HasConstraintName("FK_DETALHE_FABRICANTE");

        }
    }
}
