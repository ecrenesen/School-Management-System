using haySchool.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace haySchool.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
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

         Genel genel = new Genel();

        public IActionResult istatistik()
        {
            using (var connection = new NpgsqlConnection(Genel.conString))
               
            {
                connection.Open();

                using (var command = new NpgsqlCommand("SELECT COUNT(ogretmen_id) FROM ogretmenler", connection))
               
                {
                    var deger1 = (int)command.ExecuteScalar();
                    ViewBag.d1 = deger1;
                }
            }
            return View();
        }




        }
}
