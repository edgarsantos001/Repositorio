using ClassesDTO.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConData.Configuration
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<EmpresaDTO>
    {
        public void Configure(EntityTypeBuilder<EmpresaDTO> builder)
        {
            builder.ToTable("EMPRESA");

            builder.HasKey(k => k.empresaId);

            builder.Property(x => x.cnpj)
                .HasColumnType("Text")
                .HasDefaultValue("");

            builder.Property(x => x.razaoSocial)
                .HasColumnType("Text")
                .HasDefaultValue("");

            builder.Property(x => x.numeroAutorizacao)
                .HasColumnType("int");

            builder.Property(x => x.cnpjFormatado)
                .HasColumnType("Text")
                .HasDefaultValue("");

            builder.Property(x => x.autorizacao)
                .HasColumnType("Text")
                .HasDefaultValue("");

            builder.HasMany(c => c.content)
                   .WithOne(e => e.empresa)
                   .HasForeignKey(e => e.empresaId);



        }
    }
}
