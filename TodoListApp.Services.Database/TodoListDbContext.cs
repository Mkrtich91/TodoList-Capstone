using Microsoft.EntityFrameworkCore;

namespace TodoListApp.Services.Database
{
    public class TodoListDbContext : DbContext
    {
#pragma warning disable CS8618 
        public TodoListDbContext(DbContextOptions<TodoListDbContext> options) : base(options) { }
#pragma warning restore CS8618 
        public DbSet<TodoListEntity> TodoLists { get; set; }
    }
}
