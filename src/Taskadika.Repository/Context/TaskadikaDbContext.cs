using Microsoft.EntityFrameworkCore;

namespace Taskadika.Repository.Context;

public class TaskadikaDbContext : DbContext
{
    public TaskadikaDbContext(DbContextOptions<TaskadikaDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
