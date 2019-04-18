using ClassesDTO.DTO.MatDTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConData.Configuration
{
    public class ClasseRiscoConfiguration : IEntityTypeConfiguration<ClasseRisco>
    {
        public void Configure(EntityTypeBuilder<ClasseRisco> builder)
        {
            builder.ToTable("CLASSE_RISCO");


            builder.HasKey(x => x.classeRiscoId);
            builder.Property(v => v.descricao)
                   .HasColumnType("text")
                   .HasDefaultValue("");

            builder.Property(v => v.sigla)
                   .HasColumnType("text")
                   .HasDefaultValue("");
        }
    }
}
