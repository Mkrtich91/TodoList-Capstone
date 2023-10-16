using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoListApp.Services.Database;

[Table("todolists")]
public class TodoList
{
    [Key]
    public int Id { get; set; }

    public string Title { get; set; } = default!;
}
