using TodoList = TodoListApp.Services.TodoList;

namespace TodoListApp.WebApp.Models;

public class ModelsTodoList
{
#pragma warning disable CS8618
    public List<TodoList> TodoLists { get; set; }
#pragma warning restore CS8618
}
