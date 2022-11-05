using MVC_Curso.Models;

namespace MVC_Curso.Repositories.Interfaces {
    public interface ICategoriaRepository {

        IEnumerable<Categoria> Categorias { get; }
    }
}
