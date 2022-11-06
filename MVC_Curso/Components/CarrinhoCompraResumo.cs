using Microsoft.AspNetCore.Mvc;
using MVC_Curso.Models;
using MVC_Curso.ViewModels;

namespace MVC_Curso.Components {
    public class CarrinhoCompraResumo : ViewComponent {

        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraResumo(CarrinhoCompra carrinhoCompra) {
            _carrinhoCompra = carrinhoCompra;
        }

        public IViewComponentResult Invoke() {

            _carrinhoCompra.CarrinhoCompraItems = _carrinhoCompra.GetCarrinhoCompraItens();

            var carrinhoCompraVM = new CarrinhoCompraViewModel {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };
            return View(carrinhoCompraVM);
        }
    }
}
