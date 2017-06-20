using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AccountantSystemv5.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Sale()
        {
            return View();
        }

        public IActionResult Acquisition()
        {
            return View();
        }
        public IActionResult Hr()
        {
            return View();
        }
        public IActionResult Financing()
        {
            return View();
        }
        public IActionResult InventoryPage()
        {
            return View();
        }
    }
}
