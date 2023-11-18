namespace TodoListApp.Services.Database;
public class TaskEntity
{
    public int Id { get; set; }
    public int TodoListId { get; set; }
    public string? Title { get; set; }

    public string? Description { get; set; }
    public int NumberOfTasks { get; set; }
    public bool IsShared { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
