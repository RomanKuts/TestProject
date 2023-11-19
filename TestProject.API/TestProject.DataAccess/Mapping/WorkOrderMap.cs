using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestProject.Domain.Entities;

namespace TestProject.DataAccess.Mapping;

public class WorkOrderMap : IEntityTypeConfiguration<WorkOrder>
{
    public void Configure(EntityTypeBuilder<WorkOrder> builder)
    {
        builder.ToTable("WorkOrders");

        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Visits)
            .WithOne(x => x.WorkOrder)
            .HasForeignKey(x => x.WorkOrderId);
    }
}