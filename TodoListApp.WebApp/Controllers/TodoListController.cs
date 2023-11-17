using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TodoListApp.Services;
using TodoListApp.Services.WebApi;
using TodoListApp.WebApp.Models;

namespace TodoListApp.WebApp.Controllers;
public class TodoListController : Controller
{
    private readonly TodoListWebApiService _todoListService;
    public TodoListController(TodoListWebApiService todoListService)
    {
        this._todoListService = todoListService;
    }

    public async Task<IActionResult> Index()
    {
        var todoLists = await this._todoListService.GetTodoListsAsync();
#pragma warning disable IDE0017
        ModelsTodoList modelsTodoList = new ModelsTodoList();
#pragma warning restore IDE0017
#pragma warning disable IDE0017
        modelsTodoList.TodoLists = todoLists;
#pragma warning restore IDE0017
        return this.View(modelsTodoList);
    }

    [HttpGet]
    public ViewResult GetList()
    {
        return this.View();
    }

    [HttpPost]
    public async Task<IActionResult> GetList(int id)
    {
        var todoList = await this._todoListService.GetTodoByIdAsync(id);
#pragma warning disable IDE0009
        return View(todoList);
#pragma warning restore IDE0009
    }

    [HttpGet]
    public ViewResult Add()
    {
        return this.View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(TodoList newTodoList)
    {
        if (this.ModelState.IsValid)
        {
            await this._todoListService.AddTodoListAsync(newTodoList);
        }

        return this.RedirectToAction("Index");
    }
    public IActionResult Delete()
    {
        return this.View();
    }
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await this._todoListService.DeleteTodoListAsync(id);
#pragma warning disable IDE0009
        return RedirectToAction("Index");
#pragma warning restore IDE0009
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
#pragma warning disable S1854
        TodoList todoList = new TodoList();
#pragma warning restore S1854
        using (var httpClient = new HttpClient())
        {
#pragma warning disable IDE0063
#pragma warning disable S1075
            using (var response = await httpClient.GetAsync("https://localhost:7144/api/TodoList/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
#pragma warning disable CS8600
                todoList = JsonConvert.DeserializeObject<TodoList>(apiResponse);
#pragma warning restore CS8600
            }
#pragma warning restore S1075
#pragma warning restore IDE0063
        }
        return this.View(todoList);
    }

    [HttpPost]
    public async Task<IActionResult> Update(TodoList updatedTodoList)
    {
        var result = await this._todoListService.UpdateTodoListAsync(updatedTodoList);
        if (result)
        {
            return this.RedirectToAction("Index");
        }
        return this.View();
    }
}
