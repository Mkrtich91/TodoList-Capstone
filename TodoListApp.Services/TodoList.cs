using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoListApp.Services;
public class TodoList
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Please enter List name.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Please enter description for list.")]
    public string Description { get; set; }
    public int NumberOfTasks { get; set; }
    public bool IsShared { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
