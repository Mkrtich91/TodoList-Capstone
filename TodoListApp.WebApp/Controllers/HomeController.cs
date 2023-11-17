using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TodoListApp.WebApp.Models;

namespace TodoListApp.WebApp.Controllers;
public class HomeController : Controller
{
#pragma warning disable IDE0052
#pragma warning disable S4487
    private readonly ILogger<HomeController> _logger;
#pragma warning restore S4487
#pragma warning restore IDE0052

    public HomeController(ILogger<HomeController> logger)
    {
        this._logger = logger;
    }

    public IActionResult Index()
    {
#pragma warning disable IDE0009
        return View();
#pragma warning restore IDE0009
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
#pragma warning disable IDE0009
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
#pragma warning restore IDE0009
    }
}
