using ClassesDTO.DTO.MatDTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConData.Configuration
{
    public class FabricanteConfiguration : IEntityTypeConfiguration<Fabricante>
    {
        public void Configure(EntityTypeBuilder<Fabricante> builder)
        {
            builder.ToTable("MATERIAL_CONTENT");
            builder.HasKey(k => k.fabricanteId);

            builder.Property(x => x.atividade)
                .HasColumnType("Text")
                .HasDefaultValue("");

            builder.Property(x => x.razaoSocial)
                .HasColumnType("Text")
                .HasDefaultValue("");

            builder.Property(x => x.razaoSocial)
                 .HasColumnType("Text")
                 .HasDefaultValue("");

            builder.Property(x => x.pais)
                 .HasColumnType("Text")
                 .HasDefaultValue("");

            builder.Property(x => x.local)
                 .HasColumnType("Text")
                 .HasDefaultValue("");
        }
    }
}
