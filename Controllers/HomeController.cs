using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CRUDelicious.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private static MyContext _context;



        public HomeController(MyContext DBcontext)
        {
            _context = DBcontext;
        }

        public IActionResult Index()
        {
            ViewBag.Dishes = _context.Dishes
            .OrderByDescending(l => l.CreatedAt)
            .ToList();
            return View();
        }
        [HttpGet("new")]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult CreateDish(Dish newDish)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newDish);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("New");
            }
        }
        public IActionResult Success()
        {
            return View();
        }
        [HttpGet("/{DishID}")]
        public IActionResult Details(int DishID)
        {

            ViewBag.Details = _context.Dishes
            .FirstOrDefault(d => d.DishId == DishID);
            return View();
        }
        [HttpGet("edit/{DishID}")]
        public IActionResult Edit(int DishID)
        {
            ViewBag.Details = _context.Dishes
            .FirstOrDefault(d => d.DishId == DishID);
            return View();
        }
        [HttpPost("editdish/{DishID}")]
        public IActionResult EditDish(int DishID, Dish updatedDish)
        {
            if (ModelState.IsValid)
            {
                Dish oneDish = _context.Dishes
                            .FirstOrDefault(d => d.DishId == DishID);
                oneDish.ChefName = updatedDish.ChefName;
                oneDish.DishName = updatedDish.DishName;
                oneDish.Desc = updatedDish.Desc;
                oneDish.Tastiness = updatedDish.Tastiness;
                oneDish.NumCalories = updatedDish.NumCalories;
                oneDish.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else{
                return View("Edit", updatedDish);
            }

        }

        [HttpGet("delete/{DishID}")]
        public IActionResult Delete(int DishID)
        {
            Dish oneDish = _context.Dishes
            .FirstOrDefault(d => d.DishId == DishID);
            _context.Remove(oneDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
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
}
