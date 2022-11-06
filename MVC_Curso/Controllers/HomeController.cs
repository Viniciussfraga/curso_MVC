using Microsoft.AspNetCore.Mvc;
using MVC_Curso.Models;
using MVC_Curso.Repositories.Interfaces;
using MVC_Curso.ViewModels;
using System.Diagnostics;
using System.Linq.Expressions;

namespace MVC_Curso.Controllers {
    public class HomeController : Controller {

        private readonly ILancheRepository _lancheRepository;

        public HomeController(ILancheRepository lancheRepository) {
            _lancheRepository = lancheRepository;
        }

        public IActionResult Index() {
            var homeViewModel = new HomeViewModel {
                LanchesPreferidos = _lancheRepository.LanchesPreferidos
            };
            return View(homeViewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}