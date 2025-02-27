using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08_Team0114.Models;

namespace Mission08_Team0114.Controllers;

public class HomeController : Controller
{
    private TasksDbContext _context;

    public HomeController(TasksDbContext temp)
    {
        _context = temp;
    }

    public IActionResult Quadrants()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}