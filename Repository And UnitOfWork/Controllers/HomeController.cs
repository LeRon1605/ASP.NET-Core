using FirstProject_MVC.Models;
using FirstProject_MVC.Models.Data;
using FirstProject_MVC.Models.Entity;
using FirstProject_MVC.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FirstProject_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UnitOfWork _unit;

        public HomeController(ILogger<HomeController> logger, UnitOfWork unit)
        {
            _logger = logger;
            _unit = unit;
        }

        public IActionResult Index()
        {
            Account account = new Account
            {
                Email = "ronle9519@gmail.com",
                Password = "ronle876",
                User = new User
                {
                    Name = "Lê Quốc Rôn",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            _unit.AccountRepository.Add(account);
            _unit.Complete();
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
}
