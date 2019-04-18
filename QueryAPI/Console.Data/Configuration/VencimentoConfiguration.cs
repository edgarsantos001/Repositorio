using ClassesDTO.DTO.MatDTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ConData.Configuration
{
    public class VencimentoConfiguration : IEntityTypeConfiguration<Vencimento>
    {
        public void Configure(EntityTypeBuilder<Vencimento> builder)
        {
            builder.ToTable("MATERIAL_CONTENT");

          //  builder.HasKey(k=> k.vencimentoId)
            builder.Property(v => v.data)
                   .HasColumnType("text")
                   .HasDefaultValue("");

            builder.Property(v => v.descricao)
                   .HasColumnType("text")
                   .HasDefaultValue("");
        }
    }
}
