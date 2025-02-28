using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.EntityFrameworkCore;
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
        var tasks = _context.Tasks
            .Include(x=>x.Categories)
            .Where(x => x.completed == 0)
            .ToList();
        
        return View(tasks);
    }

    [HttpGet]
    public IActionResult AddTask()
    {
        ViewBag.Categories = _context.Categories.ToList();

        return View("AddTask", new Mission08_Team0114.Models.Task());
    }

    [HttpPost]
    public IActionResult AddTask(Mission08_Team0114.Models.Task response)
    {
        if (ModelState.IsValid)
        {
            _context.Tasks.Add(response); // Add record to the database
            _context.SaveChanges();

            return RedirectToAction("Quadrants", response);
        }
        else // Invalid data
        {
            ViewBag.Categories = _context.Categories
            .ToList();

            return View(response);
        }
    }

    public IActionResult Delete(int taskId)
    {
        var taskToDelete = _context.Tasks
                .Single(x => x.taskId == taskId);

        return View(taskToDelete);
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