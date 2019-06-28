using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoboTinic.RoboDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoboTinic.Configuration
{
    public class MaterialConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.ToTable("Material");
            builder.HasKey(k => k.Id).HasName("Material_ID");
            builder.Property(m => m.totalElements)
                   .HasColumnType("int")
                   .HasColumnName("TOTAL_ELEMENTS");

            builder.Property(r => r.DataAtualizacao)
                    .HasColumnType("DATE")
                    .HasColumnName("DT_ATUALIZADO")
                    .HasDefaultValue(DateTime.Now);
        }
    }
}
