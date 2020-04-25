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
        private readonly ServicosDepartamento _servicosDepartamento;

        public VendedoresController (ServicosVendedor servicosVendedor,ServicosDepartamento servicosDepartamento)
        {
            _servicosVendedor = servicosVendedor;
            _servicosDepartamento = servicosDepartamento;

        }


        public IActionResult Index()
        {
            var lista = _servicosVendedor.AcharTodos();
            return View(lista);
        }

        public IActionResult Create()
        {
            var departamentos = _servicosDepartamento.AcharTodos();
            var viewModel = new VendedoresViewModels { Departamentos = departamentos};
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor obj)
        {
            _servicosVendedor.Inserir(obj);
            return RedirectToAction(nameof (Index));
        }

    }
}