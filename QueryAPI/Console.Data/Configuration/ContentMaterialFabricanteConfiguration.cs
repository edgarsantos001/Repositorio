using ClassesDTO.DTO.MatDTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConData.Configuration
{
    public class ContentMaterialFabricanteConfiguration : IEntityTypeConfiguration<ContentMaterialFabricante>
    {
        public void Configure(EntityTypeBuilder<ContentMaterialFabricante> builder)
        {
            //builder.ToTable("CONTENT_FABRICANTE");

            //builder.HasKey(cf => new { cf.contentId, cf.fabricanteId });

            //builder.HasOne(cf => cf.Content)
            //       .WithMany(c => c.MaterialFabricante)
            //       .HasForeignKey(cf => cf.contentId);

            //builder.HasOne(cf => cf.Fabricante)
            //       .WithMany(c => c.MaterialFabricante)
            //       .HasForeignKey(cf => cf.fabricanteId);
        }
    }
}
