using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoboTinic.RoboDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoboTinic.Configuration
{
    public class MensagemConfiguration : IEntityTypeConfiguration<Mensagem>
    {
        public void Configure(EntityTypeBuilder<Mensagem> builder)
        {
            builder.ToTable("Mensagem");
            builder.HasKey(m => m.id).HasName("MENSAGEM_ID");
            builder.Property(m => m.motivo)
                .HasColumnName("MOTIVO")
                .HasColumnType("VARCHAR(500)");

            builder.Property(m => m.resolucao)
                .HasColumnName("RESOLUCAO")
                .HasColumnType("VARCHAR(500)");

            builder.Property(m => m.situacao)
                .HasColumnName("SITUACAO")
                .HasColumnType("VARCHAR(500)");

            builder.Property(m => m.negativo)
                .HasColumnName("NEGATIVO")
                .HasColumnType("bit");

            builder.HasOne(c => c.content)
                   .WithOne(e => e.mensagem)
                   .HasForeignKey<Mensagem>(c => c.contentId)
                   .HasConstraintName("FK_CONTENT_MENSAGEM");
        }
    }
}
