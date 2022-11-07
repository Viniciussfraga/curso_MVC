﻿using Microsoft.AspNetCore.Mvc;
using MVC_Curso.Models;
using MVC_Curso.Repositories.Interfaces;
using MVC_Curso.ViewModels;

namespace MVC_Curso.Controllers {
    public class LancheController : Controller {

        private readonly ILancheRepository _lancheRepository;

        public LancheController(ILancheRepository lancheRepository) {
            _lancheRepository = lancheRepository;
        }

        public IActionResult List(string categoria) {

            IEnumerable<Lanche> lanches;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria)) {
                lanches = _lancheRepository.Lanches.OrderBy(l => l.LancheId);
                categoriaAtual = "Todos os lanches";
            }
            else {
                lanches = _lancheRepository.Lanches
                        .Where(l => l.Categoria.CategoriaNome.Equals(categoria))
                        .OrderBy(c => c.Nome);

            }
            categoriaAtual = categoria;

            var lanchesListViewModel = new LancheListViewModel {
                Lanches = lanches,
                CategoriaAtual = categoriaAtual,

            };
            return View(lanchesListViewModel);

        }

        public IActionResult Details(int lancheId) {
            var lanche = _lancheRepository.Lanches.FirstOrDefault(l => l.LancheId == lancheId);
            return View(lanche);
        }
    }
}
