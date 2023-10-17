using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoListApp.Services.Database;

[Table("todo_lists")]
public class TodoListEntity
{
    [Key]
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public int NumberOfTasks { get; set; }

    public bool IsShared { get; set; }
}
