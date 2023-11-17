using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoListApp.Services.Database;

namespace TodoListApp.Services.Database;
public class TodoListDatabaseService : ITodoListService
{
    private readonly TodoListDbContext _context;

    public TodoListDatabaseService(TodoListDbContext dbContext)
    {
        this._context = dbContext;
    }

    public async Task CreateTodoListAsync(TodoList todoList)
    {
        var entity = new TodoListEntity
        {
            Title = todoList.Title,
            Description = todoList.Description,
            CreatedAt = todoList.CreatedAt,
            NumberOfTasks = todoList.NumberOfTasks,
            IsShared = todoList.IsShared,
        };

        this._context.TodoLists.Add(entity);
        await this._context.SaveChangesAsync();
    }

    public async Task DeleteTodoListAsync(int id)
    {
        var entity = await this._context.TodoLists.FindAsync(id);
        if (entity != null)
        {
            this._context.TodoLists.Remove(entity);
            await this._context.SaveChangesAsync();
        }
    }

    public async Task<TodoList?> GetTodoListByIdAsync(int id)
    {
        var entity = await this._context.TodoLists.FindAsync(id);
        if (entity != null)
        {
            return new TodoList
            {
                Id = entity.Id,
                Title = entity.Title,
                Description = entity.Description,
                CreatedAt = entity.CreatedAt,
                NumberOfTasks = entity.NumberOfTasks,
                IsShared = entity.IsShared,
            };
        }

        return null;
    }

    public async Task<IEnumerable<TodoList>> GetTodoListsAsync()
    {
        return await this._context.TodoLists
            .Select(t => new TodoList
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                CreatedAt = t.CreatedAt,
                NumberOfTasks = t.NumberOfTasks,
                IsShared = t.IsShared
            })
            .ToListAsync();
    }

    public async Task UpdateTodoListAsync(TodoList todoList)
    {
        var entity = await this._context.TodoLists.FindAsync(todoList.Id);
        if (entity != null)
        {
            entity.Title = todoList.Title;
            entity.Description = todoList.Description;

            await this._context.SaveChangesAsync();
        }
    }
}
