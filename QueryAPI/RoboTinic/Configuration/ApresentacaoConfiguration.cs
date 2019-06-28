using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoboTinic.RoboDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoboTinic.Configuration
{
    public class ApresentacaoConfiguration : IEntityTypeConfiguration<Apresentacao>
    {
        public void Configure(EntityTypeBuilder<Apresentacao> builder)
        {
            builder.ToTable("APRESENTACAO_MATERIAL");
            builder.HasKey(d => d.Id)
                   .HasName("APRESENTACAO_ID");

            builder.Property(a => a.modelo)
                .HasColumnType("TEXT")
                .HasColumnName("MODELO");

            builder.Property(a => a.componente)
                   .HasColumnType("VARCHAR(4000)")
                   .HasColumnName("COMPONENTE");

            builder.Property(a => a.apresentacao)
                   .HasColumnType("VARCHAR(4000)")
                   .HasColumnName("APRESENTACAO");

            builder.HasOne(p => p.content)
                      .WithMany(c => c.apresentacoes)
                      .HasForeignKey(k => k.contentId)
                      .OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_Detalhe_Apresentacao");


            //builder.HasOne(p => p.detalhe)
            //          .WithMany(c => c.apresentacoes)
            //          .HasForeignKey(k => k.detalheId)
            //          .OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_Detalhe_Apresentacao");


        }
    }
}
