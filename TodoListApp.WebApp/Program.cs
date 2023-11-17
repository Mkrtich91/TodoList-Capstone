using Microsoft.EntityFrameworkCore;
using TodoListApp.Services.Database;
using TodoListApp.Services.WebApi;

namespace TodoListApp.WebApp;

#pragma warning disable S1118
public class Program
#pragma warning restore S1118
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        _ = builder.Services.AddControllersWithViews();
        _ = builder.Services.AddDbContext<TodoListDbContext>(options =>
        {
            _ = options.UseSqlServer(builder.Configuration.GetConnectionString("MyCon"));
        });
        _ = builder.Services.AddHttpClient<TodoListWebApiService>(client =>
        {
#pragma warning disable S1075
            client.BaseAddress = new Uri("https://localhost:7144");
#pragma warning restore S1075
        });

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            _ = app.UseExceptionHandler("/Home/Error");
            _ = app.UseHsts();
        }

        _ = app.UseHttpsRedirection();
        _ = app.UseStaticFiles();

        _ = app.UseRouting();

        _ = app.UseAuthorization();

        _ = app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
