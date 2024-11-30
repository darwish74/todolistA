using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todolistA.Data;
using todolistA.Models;

namespace todolistA.Controllers
{
    public class TaskManagerController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ShowAll(string name)
        {   if (name != null)
                ViewBag.personName = name;
            else
                ViewBag.personName = "your tasks below";
            var per = _context.Tasks.ToList();
            return View(per);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Tasky task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return RedirectToAction("ShowAll");
        }
        public IActionResult Delete(int id) 
        {
            var task1 = _context.Tasks.Find(id);
            if (task1 != null)
            {
                _context.Tasks.Remove(task1);
                _context.SaveChanges();
            }
            return RedirectToAction("ShowAll");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var task=_context.Tasks.Find(id);
            if(task != null)
            {
                return View(task);
            }
            return RedirectToAction("ShowAll");
        }
        [HttpPost]
        public IActionResult Edit(int id, string title, string description, DateTime deadline)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
            {
                TempData["Error"] = "Task not found.";
                return RedirectToAction("ShowAll");
            }

            task.Title = title;
            task.Description = description;
            task.DeadLine = deadline;

            _context.SaveChanges();

            return RedirectToAction("ShowAll");
        }


    }
}
