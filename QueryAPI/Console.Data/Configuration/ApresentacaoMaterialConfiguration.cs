using ClassesDTO.DTO.MatDTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConData.Configuration
{
    public class ApresentacaoMaterialConfiguration : IEntityTypeConfiguration<ApresentacaoMaterial>
    {
        public void Configure(EntityTypeBuilder<ApresentacaoMaterial> builder)
        {
            builder.ToTable("APRESENTACAO_MATERIAL");

            builder.HasKey(k=> k.apresentacaoId);

            builder.Property(x => x.modelo)
                   .HasColumnType("Text")
                   .HasDefaultValue("");

            builder.Property(x => x.componente)
                   .HasColumnType("Text")
                   .HasDefaultValue("");

            builder.Property(x => x.apresentacao)
                   .HasColumnType("Text")
                   .HasDefaultValue("");

        }
    }
}
