using Microsoft.EntityFrameworkCore;
using TestProject.Domain.Entities;

namespace TestProject.DataAccess.DataContext;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WorkOrder>();
        modelBuilder.Entity<Visit>();
        modelBuilder.Entity<Part>();
    }
}