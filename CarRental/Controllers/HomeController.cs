using CarRental.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace CarRental.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        ICarRepository repo;

        public HomeController(ILogger<HomeController> logger,  ICarRepository r)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
           
            repo = r;
        }
        
       
        public IActionResult Index()
        {
            _logger.LogInformation("Запуск стартовой страницы");
            return View(repo.GetCars());
        }
        public ActionResult Details(int id)
        {
            _logger.LogInformation("Просмотр записей");
            Car car = repo.Get(id);
            if (car != null)
                return View(car);
            return NotFound();
        }

        public ActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Create(Car car)

        {
            _logger.LogInformation("Создание новых записей");
            repo.Create(car);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            _logger.LogInformation("Изменение данных");
            Car car = repo.Get(id);
            if (car != null)
                return View(car);
            return NotFound();
        }

        [HttpPost]
        public ActionResult Edit(Car car)
        {
            repo.Update(car);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            _logger.LogInformation("Удаление данных");
            Car car = repo.Get(id);
            if (car != null)
                return View(car);
            return NotFound();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }

      
    }
}
