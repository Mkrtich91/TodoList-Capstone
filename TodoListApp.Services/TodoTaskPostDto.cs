
namespace TodoListApp.Services;
public class TodoTaskPostDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int TodoListId { get; set; }
}
