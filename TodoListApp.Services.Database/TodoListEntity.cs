using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoListApp.Services.Database;

[Table("todo_lists")]
public class TodoListEntity
{
    [Key]
    public int Id { get; set; }

    public string Title { get; set; } = default!;
}
