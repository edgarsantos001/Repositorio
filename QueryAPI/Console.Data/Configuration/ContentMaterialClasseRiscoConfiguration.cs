using ClassesDTO.DTO.MatDTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConData.Configuration
{
    public class ContentMaterialClasseRiscoConfiguration : IEntityTypeConfiguration<ContentClasseRisco>
    {
        public void Configure(EntityTypeBuilder<ContentClasseRisco> builder)
        {
            builder.ToTable("CONTENT_CLASSERISCO");

            builder.HasKey(cc => new { cc.contentId, cc.classeRiscoId});

            //builder.HasOne(cc => cc.Content)
            //       .WithMany(c => c.MaterialClasseRisco)
            //       .HasForeignKey(cc => cc.contentId);

            builder.HasOne(cf => cf.ClasseRisco)
                   .WithMany(c => c.MaterialClasseRisco)
                   .HasForeignKey(cf => cf.classeRiscoId);
        }
    }
}
