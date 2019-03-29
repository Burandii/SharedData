using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SharedData.KWIC;
using SharedData.Models;

namespace SharedData.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var sharedDataKWIC = new KWICController();

            var testString = "Pipe and Filter\nSoftware Architecture in Practice";

            sharedDataKWIC.SetInput(testString);

            var result3 = sharedDataKWIC.GenerateSomething();
            var result4 = sharedDataKWIC.GenerateSomethingList();

            return View();
        }

        [HttpPost]
        public IActionResult GetKWICResult(string input)
        {
            var sharedDataKWIC = new KWICController();

            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
