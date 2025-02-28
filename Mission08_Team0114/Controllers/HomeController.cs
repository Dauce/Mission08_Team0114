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
            .Include(x => x.Categories)
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
        else
        {
            ViewBag.Categories = _context.Categories.ToList();

            return View("AddTask", new Mission08_Team0114.Models.Task());
        }
    }

    [HttpGet]

    public IActionResult Delete(int taskId)
    {
        var taskToDelete = _context.Tasks
            .Single(x => x.taskId == taskId);

        return View(taskToDelete);
    }

    [HttpPost]
    public IActionResult Delete(Mission08_Team0114.Models.Task task)
    {
        _context.Tasks.Remove(task);
        _context.SaveChanges();
        return RedirectToAction("Quadrants", task);
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







    [HttpGet]

    public IActionResult EditTask(int taskId)
    {
        Mission08_Team0114.Models.Task task = _context.Tasks
            .Where(x => x.taskId == taskId)
            .SingleOrDefault();
        if (task == null)
        {
            return NotFound(); // Prevents a null reference error if the task doesn't exist
        }

        ViewBag.Categories = _context.Categories
            .OrderBy(x =>x.categoryId)
            .ToList();
        return View("AddTask", task);
    }

    [HttpPost]
    public IActionResult EditTask(Mission08_Team0114.Models.Task response)
    {
        if (ModelState.IsValid)
        {
            _context.Tasks.Update(response); // Add record to the database
            _context.SaveChanges();

            return RedirectToAction("Quadrants", response);
        }
        else // Invalid data
        {
            ViewBag.Categories = _context.Categories
                .ToList();

            return View("AddTask", response);
        }
    }
}