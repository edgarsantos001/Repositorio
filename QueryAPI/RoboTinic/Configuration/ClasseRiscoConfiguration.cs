using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoboTinic.RoboDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoboTinic.Configuration
{
    public class ClasseRiscoConfiguration : IEntityTypeConfiguration<ClasseRisco>
    {
        public void Configure(EntityTypeBuilder<ClasseRisco> builder)
        {
            builder.ToTable("CLASSE_RISCO");
            builder.HasKey(d => d.Id).HasName("CLASSE_RISCO_ID");

            builder.Property(n => n.sigla)
                .HasColumnType("VARCHAR(10)")
                .HasColumnName("SIGLA");

            builder.Property(r => r.descricao)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("DESCRICAO");

            builder.HasOne(c => c.content)
                   .WithOne(e => e.risco)
                   .HasForeignKey<ClasseRisco>(c => c.contentId)
                   .HasConstraintName("FK_DETALHE_CLASSE_RISCO");

            //builder.HasOne(c => c.detalhe)
            //       .WithOne(e => e.risco)
            //       .HasForeignKey<ClasseRisco>(c => c.detalheId)
            //       .HasConstraintName("FK_DETALHE_CLASSE_RISCO");

        }
    }
}
