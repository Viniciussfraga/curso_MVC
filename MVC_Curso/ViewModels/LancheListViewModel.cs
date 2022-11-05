using MVC_Curso.Models;

namespace MVC_Curso.ViewModels {
    public class LancheListViewModel {

        public IEnumerable<Lanche> Lanches { get; set; }
        public string CategoriaAtual { get; set; } 
    }
}
