using Microsoft.EntityFrameworkCore;
using TodoListApp.Services.Database;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TodoListDbContext>(options =>
{
    _ = options.UseSqlServer(connectionString);
});

//builder.Services.AddDbContext<TodoListDbContext>(options => options.UseInMemoryDatabase("TodoListDb"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
   // app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// dotnet ef migrations add InitialCreate -s ..\TodoListApp.WebApi
// dotnet ef database update --startup-project ..\TodoListApp.WebApi


// c:\Work\garbage\mkrtich91-todo-list-app\TodoListApp.WebApi>dotnet ef migrations add InitialCreate --project ..\TodoListApp.Services.Database
// c:\Work\garbage\mkrtich91-todo-list-app\TodoListApp.WebApi>dotnet ef database update --project ..\TodoListApp.Services.Database
