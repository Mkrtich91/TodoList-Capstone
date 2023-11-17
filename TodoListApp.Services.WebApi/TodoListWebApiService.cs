using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListApp.Services.WebApi
{
    public class TodoListWebApiService
    {
        private readonly HttpClient _httpClient;
        public TodoListWebApiService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<List<TodoList>> GetTodoListsAsync()
        {
            var response = await this._httpClient.GetAsync("/api/TodoList");
            response.EnsureSuccessStatusCode();

            var todoLists = await response.Content.ReadAsAsync<List<TodoList>>();
            return todoLists;
        }
        public async Task<TodoList> GetTodoByIdAsync(int id)
        {
            var response = await this._httpClient.GetAsync($"/api/TodoList/{id}");
            response.EnsureSuccessStatusCode();

            var todoList = await response.Content.ReadAsAsync<TodoList>();
            return todoList;
        }

        public async Task AddTodoListAsync(TodoList newTodoList)
        {
            var response = await this._httpClient.PostAsJsonAsync("/api/TodoList", newTodoList);
            response.EnsureSuccessStatusCode();
        }
        public async Task DeleteTodoListAsync(int id)
        {
            var response = await this._httpClient.DeleteAsync($"/api/TodoList/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
