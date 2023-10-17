namespace TodoListApp.Services.Database;
public class TodoListDatabaseService : ITodoListService
{

    private readonly TodoListDbContext context;
    public TodoListDatabaseService(TodoListDbContext context)
    {
        this.context = context;
    }

    public IEnumerable<TodoList> GetTodoLists()
    {
        return this.context.TodoLists.Select(l => new TodoList { Id = l.Id });
    }


}
