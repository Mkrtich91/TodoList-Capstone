using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TodoListApp.Services.Database;
public class TodoListDatabaseServices:ITodoListService
{
    private readonly TodoListDbContext _dbContext;

    public TodoListDatabaseServices(TodoListDbContext dbContext)
    {
        _dbContext=dbContext;
    }

    public async Task CreateTodoListAsync(TodoListPostDTO todoList)
    {
        var entity = new TodoList
        {
            Id = todoList.Id,
            Title= todoList.Title,
            Description = todoList.Description,
            IsShared= todoList.IsShared,
        };

        this._dbContext.TodoLists.Add(entity);
        await this._dbContext.SaveChangesAsync();
    }

    public async Task DeleteTodoListAsync(int id)
    {
        var entity = await this._dbContext.TodoLists.FindAsync(id);
        if (entity != null)
        {
            this._dbContext.TodoLists.Remove(entity);
            await this._dbContext.SaveChangesAsync();
        }
    }

    public async Task<Services.TodoList?> GetTodoListByIdAsync(int id)
    {
        var entity = await this._dbContext.TodoLists.FindAsync(id);
        if (entity != null) { return new Services.TodoList { Id = entity.Id, Title = entity.Title, Description = entity.Description, IsShared = entity.IsShared }; }
        return null;
    }

    public async Task<IEnumerable<TodoList>> GetTodoListsAsync() { return await this._dbContext.TodoLists.Select(t => new TodoList { Id = t.Id, Title = t.Title, Description = t.Description, NumberOfTasks = t.NumberOfTasks, IsShared = t.IsShared }).ToListAsync(); }

    public Task UpdateTodoListAsync(TodoListPostDTO todoList)
    {
        throw new NotImplementedException();
    }
}
