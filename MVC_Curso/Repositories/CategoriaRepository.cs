using MVC_Curso.Context;
using MVC_Curso.Models;
using MVC_Curso.Repositories.Interfaces;

namespace MVC_Curso.Repositories {
    public class CategoriaRepository : ICategoriaRepository {

        private readonly AppDbContext _context;

        public CategoriaRepository(AppDbContext context) {
            _context = context;
        }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }
}
