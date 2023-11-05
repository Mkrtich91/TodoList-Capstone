using Microsoft.AspNetCore.Mvc;
using TodoListApp.Services;

namespace TodoListApp.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoListController : ControllerBase
{
    private readonly ITodoListService _todoListService;

    public TodoListController(ITodoListService todoListService)
    {
        _todoListService = todoListService;
    }

    [HttpGet]
    public IEnumerable<TodoList> GetTodoLists()
    {
        // Use the injected service to retrieve TodoLists
        var todoLists = _todoListService.GetTodoLists();
        return todoLists;
    }
}
