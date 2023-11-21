using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TodoListApp.Services;
using TodoListApp.Services.WebApi;
using TodoListApp.WebApp.Models;

namespace TodoListApp.WebApp.Controllers
{
    public class TodoTaskController : Controller
    {
        private readonly TodoTaskWebApiService _todoTaskService;
        public TodoTaskController(TodoTaskWebApiService todoTaskService)
        {
            this._todoTaskService = todoTaskService;
        }

        public async Task<IActionResult> Index()
        {
            var todoTasks = await this._todoTaskService.GetTodoTasksAsync();
#pragma warning disable IDE0017
            ModelsTodoTask modelsTodoTask = new();
#pragma warning restore IDE0017
#pragma warning disable IDE0017
            modelsTodoTask.TodoTasks = todoTasks;
#pragma warning restore IDE0017
            return this.View(modelsTodoTask);
        }

        [HttpGet]
        public ViewResult GetTask()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> GetTask(int id)
        {
            var todoTask = await this._todoTaskService.GetTodoByIdAsync(id);
#pragma warning disable IDE0009
            return View(todoTask);
#pragma warning restore IDE0009
        }

        [HttpGet]
        public ViewResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(TodoTask newTodoTask)
        {
            if (this.ModelState.IsValid)
            {
                await this._todoTaskService.AddTodoTaskAsync(newTodoTask);
            }

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this._todoTaskService.DeleteTodoTaskAsync(id);
#pragma warning disable IDE0009
            return RedirectToAction("Index");
#pragma warning restore IDE0009
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
#pragma warning disable S1854
            TodoTask todoTask = new();
#pragma warning restore S1854
            using (var httpClient = new HttpClient())
            {
#pragma warning disable IDE0063
#pragma warning disable S1075
                using (var response = await httpClient.GetAsync("https://localhost:7144/api/TodoTask/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
#pragma warning disable CS8600
                    todoTask = JsonConvert.DeserializeObject<TodoTask>(apiResponse);
#pragma warning restore CS8600
                }
#pragma warning restore S1075
#pragma warning restore IDE0063
            }

            return this.View(todoTask);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TodoTask updatedTodoTask)
        {
            var result = await this._todoTaskService.UpdateTodoTaskAsync(updatedTodoTask);
            if (result)
            {
                return this.RedirectToAction("Index");
            }

            return this.View();
        }
    }
}
