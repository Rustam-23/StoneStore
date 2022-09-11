using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StoneStore.Data;
using StoneStore.Models;
using StoneStore.Models.ViewModels;

namespace StoneStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly StoneDbContext _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, StoneDbContext db)
        {
            _db = db;
            _logger = logger;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                Products = _db.Product.Include(u => u.Category).Include(u => u.ApplicationType),
                Categories = _db.Category
            };
                
            return View(homeVM);
        }

        public IActionResult Details(int id)
        {
            DetailsVM DetailsVM = new DetailsVM()
            {
                Product = _db.Product
                    .Include(u => u.Category)
                    .Include(u => u.ApplicationType)
                    .FirstOrDefault(u => u.Id == id),
                ExistsInCart = false
            };

            return View(DetailsVM);
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