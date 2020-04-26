using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasMVCWeb.Models;
using VendasMVCWeb.Models.ViewModels;
using VendasMVCWeb.Services;

namespace VendasMVCWeb.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly ServicosVendedor _servicosVendedor;
        private readonly ServicoDepartamento _servicoDepartamento;

        public VendedoresController (ServicosVendedor servicosVendedor, ServicoDepartamento servicoDepartamento)
        {
            _servicosVendedor = servicosVendedor;
            _servicoDepartamento = servicoDepartamento;
        }


        public IActionResult Index()
        {
            var lista = _servicosVendedor.AcharTodos();
            return View(lista);
        }

        public IActionResult Create()
        {
            var departamentos = _servicoDepartamento.AcharTodos();
            var viewModel = new VendedorFormViewModel { Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
            _servicosVendedor.Inserir(vendedor);
            return RedirectToAction(nameof (Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _servicosVendedor.AcharPorId(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _servicosVendedor.Remover(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _servicosVendedor.AcharPorId(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

    }
}