using Microsoft.AspNetCore.Mvc;
using MVC_Curso.Models;
using MVC_Curso.Repositories.Interfaces;
using MVC_Curso.ViewModels;

namespace MVC_Curso.Controllers {
    public class CarrinhoCompraController : Controller {

        private readonly ILancheRepository _lancheRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(ILancheRepository lancheRepository, CarrinhoCompra carrinhoCompra) {
            _lancheRepository = lancheRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Index() {

            _carrinhoCompra.CarrinhoCompraItems = _carrinhoCompra.GetCarrinhoCompraItens();

            var carrinhoCompraVM = new CarrinhoCompraViewModel {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };

            return View(carrinhoCompraVM);
        }

        public IActionResult AdicionarItemNoCarrinhoCompra(int lancheId) {
            var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault(p => p.LancheId == lancheId);

            if (lancheSelecionado != null) {
                _carrinhoCompra.AdicionarAoCarrinho(lancheSelecionado);

            }
            return RedirectToAction("Index");
        }
        public IActionResult RemoverItemDoCarrinhoCompra(int lancheId) {

            var lancheSelecionado = _lancheRepository.Lanches.FirstOrDefault(p => p.LancheId == lancheId);
            if (lancheSelecionado != null) {
                _carrinhoCompra.RemoverDoCarrinho(lancheSelecionado);

            }
            return RedirectToAction("Index");
        }
    }
}
