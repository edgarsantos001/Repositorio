using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoboTinic.RoboDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoboTinic.Configuration
{
    public class DetalheConfiguration :  IEntityTypeConfiguration<Detalhe>
    {
        public void Configure(EntityTypeBuilder<Detalhe> builder)
        {
            builder.ToTable("DETALHE_MATERIAL");
            builder.HasKey(d => d.Id).HasName("DETALHE_ID");

            builder.Property(n => n.nomeTecnico)
                .HasColumnType("VARCHAR(4000)")
                .HasColumnName("NM_TECNICO");

            builder.Property(r => r.registro)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("COD_ANV");

            builder.Property(r => r.cancelamento)
                .HasColumnType("VARCHAR(10)")
                .HasColumnName("CANCELADO");

            builder.Property(r => r.dataCancelamento)
                .HasColumnType("VARCHAR(30)")
                .HasColumnName("DT_CANCELADO");

            builder.Property(r => r.processo)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("PROCESSO");

            builder.Property(r => r.publicacao)
                .HasColumnType("VARCHAR(30)")
                .HasColumnName("DT_PUBLICACAO");

            builder.Property(r => r.apresentacaoModelo)
                .HasColumnType("VARCHAR(10)")
                .HasColumnName("APRESENTACAO");

        }
    }
}
