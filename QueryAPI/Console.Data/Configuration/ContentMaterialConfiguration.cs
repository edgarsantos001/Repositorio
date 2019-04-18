using ClassesDTO.DTO;
using ClassesDTO.DTO.MatDTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConData.Configuration
{
    public class ContentMaterialConfiguration : IEntityTypeConfiguration<ContentMaterial>
    {
        public void Configure(EntityTypeBuilder<ContentMaterial> builder)
        {
            builder.ToTable("MATERIAL_CONTENT");
            builder.HasKey(k => k.contentid);
            builder.Property(x => x.processo)
                .HasColumnType("Text")
                .HasDefaultValue("");

            builder.Property(x => x.produto)
                .HasColumnType("Text")
                .HasDefaultValue("");

            builder.Property(x => x.registro)
                .HasColumnType("Text")
                .HasDefaultValue("");

            builder.Property(x => x.situacao)
                .HasColumnType("Text")
                .HasDefaultValue("");

            builder.Property(x => x.nomeTecnico)
                .HasColumnType("Text")
                .HasDefaultValue("");

            builder.Property(x => x.cancelado)
                .HasColumnType("int")
                .HasDefaultValue(0);

            builder.Property(x => x.dataCancelamento)
                .HasColumnType("Text")
                .HasDefaultValue("");

            builder.Property(x => x.publicacao)
                .HasColumnType("Text")
                .HasDefaultValue("");

            builder.Property(x => x.apresentacaoModelo)
                .HasColumnType("int")
                .HasDefaultValue(0);

            //builder.HasMany(x => x.apresentacoes)
            //       .WithOne(x => x.content)
            //       .HasForeignKey(x => x.contentid);

            //builder.HasOne(d => d.vencimento)
            //       .WithOne(c => c.content)
            //       .HasForeignKey<Vencimento>(cd => cd.contentid);

        }
    }
}
