using ClassesDTO.DTO.MatDTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConData.Configuration
{
    public class MaterialConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.ToTable("MATERIAL");

            builder.HasKey(o => o.materialId);
            builder.Property(x => x.totalElementsID)
                .HasColumnType("int")
                .HasDefaultValue(0);

            builder.Property(x => x.totalPages)
                .HasColumnType("int")
                .HasDefaultValue(0);

            builder.Property(x => x.last)
                .HasColumnType("int")
                .HasDefaultValue(0);

            builder.Property(x => x.numberOfElements)
                .HasColumnType("int")
                .HasDefaultValue(0);

            builder.Property(x => x.first)
                .HasColumnType("int")
                .HasDefaultValue(0);

            builder.Property(x => x.sort)
                .HasColumnType("int")
                .HasDefaultValue(0);

            builder.Property(x => x.number)
                .HasColumnType("int")
                .HasDefaultValue(0);

            builder.Property(x => x.size)
                .HasColumnType("int")
                .HasDefaultValue(0);


            builder.HasMany<ContentMaterial>(x => x.content)
                .WithOne(s => s.material)
                .HasForeignKey(s => s.materialId);
        }
    }
}
