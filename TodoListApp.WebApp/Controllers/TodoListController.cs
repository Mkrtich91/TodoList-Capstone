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
        ModelsTodoList modelsTodoList = new ModelsTodoList();
        modelsTodoList.TodoLists = todoLists;
        return this.View(modelsTodoList);
    }

    [HttpGet]
    public ViewResult GetList()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> GetList(int id)
    {
        var todoList = await this._todoListService.GetTodoByIdAsync(id);
        return View(todoList);
    }

    [HttpGet]
    public ViewResult Add()
    {
        //var model = new TodoList();
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
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        TodoList todoList = new TodoList();
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("https://localhost:7144/api/TodoList/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                todoList = JsonConvert.DeserializeObject<TodoList>(apiResponse);
            }
        }
        return View(todoList);
    }

    [HttpPost]
    public async Task<IActionResult> Update(TodoList updatedTodoList)
    {
        TodoList todoList = new TodoList();
        if (ModelState.IsValid)
        {
            using (var httpClient = new HttpClient())
            {
                var content = new MultipartFormDataContent(); // 
                content.Add(new StringContent(updatedTodoList.Id.ToString()), "Id");
                content.Add(new StringContent(updatedTodoList.Title), "Title");
                content.Add(new StringContent(updatedTodoList.Description), "Description");
                using (var response = await httpClient.PutAsync($"https://localhost:7144/api/TodoList/{updatedTodoList.Id}", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    todoList = JsonConvert.DeserializeObject<TodoList>(apiResponse);
                }
            }
        }
        return View(todoList);
    }
}
