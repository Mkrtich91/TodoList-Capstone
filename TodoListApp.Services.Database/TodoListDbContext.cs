using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace TodoListApp.Services.Database;
public class TodoListDbContext : DbContext
{
    public TodoListDbContext(DbContextOptions<TodoListDbContext> options)
        : base(options)
    {
    }

    // Define DbSet properties for your entities (e.g., TodoItem)
    public DbSet<TodoListEntity> TodoLists { get; set; } = default!;
    protected override void OnModelCreating(DbModelBuilder modelbuilder)
    {
        modelbuilder.Conventions.Remove<PluralizingTableNameConvention>();
    }
    // Other DbSet properties for additional entities if needed
}
