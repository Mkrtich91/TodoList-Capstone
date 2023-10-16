using System.ComponentModel.DataAnnotations.Schema;

namespace TodoListApp.Services.Database;

[Table("Todolists")]
public class TodoListEntity
{
    public int Id { get; set; }

    public string Title { get; set; } = default!;
}
