using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoboTinic.RoboDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoboTinic.Configuration
{
    public class ContentConfiguration : IEntityTypeConfiguration<Content>
    {
        public void Configure(EntityTypeBuilder<Content> builder)
        {
            builder.ToTable("Content");
            builder.HasKey(c => c.id).HasName("Content_ID");

            builder.Property(c => c.processo)
                   .HasColumnName("NM_PROCESSO")
                   .HasColumnType("VARCHAR(50)");

            builder.Property(c => c.produto)
                   .HasColumnName("DESC_PRODUTO")
                   .HasColumnType("VARCHAR(50)");

            builder.Property(c => c.registro)
                   .HasColumnName("COD_ANVISA")
                   .HasColumnType("VARCHAR(50)");

            builder.Property(s => s.situacao)
                   .HasColumnName("SITUACAO")
                   .HasColumnType("VARCHAR(200)");

            builder.Property(n => n.nomeTecnico)
             .HasColumnType("VARCHAR(4000)")
             .HasColumnName("NM_TECNICO");
            
            builder.Property(r => r.registro)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("COD_ANV");

            builder.Property(r => r.cancelamento)
                .HasColumnType("BIT")
                .HasColumnName("CANCELADO");

            builder.Property(r => r.dataCancelamento)
                .HasColumnType("VARCHAR(30)")
                .HasColumnName("DT_CANCELADO");

            builder.Property(r => r.publicacao)
                .HasColumnType("VARCHAR(30)")
                .HasColumnName("DT_PUBLICACAO");

            builder.Property(r => r.apresentacaoModelo)
                .HasColumnType("BIT")
                .HasColumnName("APRESENTACAO");


            builder.Property(r => r.Atualizado)
                .HasColumnType("BIT")
                .HasColumnName("ATUALIZADO")
                .HasDefaultValue(false);

            builder.Property(r => r.Erro)
                .HasColumnType("BIT")
                .HasColumnName("ERRO")
                .HasDefaultValue(false);


            builder.HasOne(p => p.material)
                       .WithMany(c => c.content)
                       .HasForeignKey(k => k.materialId)
                       .OnDelete(DeleteBehavior.Cascade).HasConstraintName("FK_Material_Content");

        }
    }
}
