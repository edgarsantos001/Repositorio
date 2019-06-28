using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoboTinic.RoboDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoboTinic.Configuration
{
    public class VencimentoConfiguration : IEntityTypeConfiguration<Vencimento>
    {
        public void Configure(EntityTypeBuilder<Vencimento> builder)
        {
            builder.ToTable("VENCIMENTO");
            builder.HasKey(d => d.Id).HasName("VENCIMENTO_ID");

            builder.Property(n => n.data)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("DT_VENCIMENTO");

            builder.Property(r => r.descricao)
                .HasColumnType("VARCHAR(4000)")
                .HasColumnName("DESC_VENCIMENTO");

            builder.HasOne(c => c.content)
                   .WithOne(e => e.vencimento)
                   .HasForeignKey<Vencimento>(c => c.contentId)
                   .HasConstraintName("FK_DETALHE_VENCIMENTO");
            //builder.HasOne(c => c.detalhe)
            //      .WithOne(e => e.vencimento)
            //      .HasForeignKey<Vencimento>(c => c.detalheId)
            //      .HasConstraintName("FK_DETALHE_VENCIMENTO");
        }
    }
}
