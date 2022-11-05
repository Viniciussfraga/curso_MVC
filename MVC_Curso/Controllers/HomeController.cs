using Microsoft.AspNetCore.Mvc;
using MVC_Curso.Models;
using System.Diagnostics;

namespace MVC_Curso.Controllers {
    public class HomeController : Controller {

        public IActionResult Index() {

            TempData["Nome"] = "Vinicius";

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}