using Microsoft.EntityFrameworkCore;
using TodoListApp.Services;
using TodoListApp.Services.Database;

namespace TodoListApp.WebApi;

#pragma warning disable S1118
public class Program
#pragma warning restore S1118
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        _ = builder.Services.AddControllers();
        _ = builder.Services.AddEndpointsApiExplorer();
        _ = builder.Services.AddSwaggerGen();
        _ = builder.Services.AddDbContext<TodoListDbContext>(options =>
        {
            _ = options.UseSqlServer(builder.Configuration.GetConnectionString("MyCon"));
        });
        _ = builder.Services.AddScoped<ITodoListService, TodoListDatabaseService>();
        _ = builder.Services.AddControllersWithViews().AddNewtonsoftJson();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            _ = app.UseSwagger();
            _ = app.UseSwaggerUI();
        }

        _ = app.UseHttpsRedirection();

        _ = app.UseAuthorization();


        _ = app.MapControllers();

        app.Run();
    }
}
