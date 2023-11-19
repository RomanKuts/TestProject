using Microsoft.EntityFrameworkCore;
using TestProject.DataAccess.Mapping;
using TestProject.Domain.Entities;

namespace TestProject.DataAccess.DataContext;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new WorkOrderMap());
        modelBuilder.ApplyConfiguration(new VisitMap());
        modelBuilder.ApplyConfiguration(new PartMap());

        modelBuilder.Entity<WorkOrder>();
        modelBuilder.Entity<Visit>();
        modelBuilder.Entity<Part>();
    }
}