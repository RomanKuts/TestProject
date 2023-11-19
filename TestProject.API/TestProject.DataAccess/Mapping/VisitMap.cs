using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestProject.Domain.Entities;

namespace TestProject.DataAccess.Mapping;

public class VisitMap : IEntityTypeConfiguration<Visit>
{
    public void Configure(EntityTypeBuilder<Visit> builder)
    {
        builder.ToTable("Visits");

        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Parts)
            .WithOne(x => x.Visit)
            .HasForeignKey(x => x.VisitId);
    }
}