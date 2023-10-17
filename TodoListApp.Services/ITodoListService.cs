namespace TodoListApp.Services;
public interface ITodoListService
{
    IEnumerable<TodoList> GetTodoLists();
}
