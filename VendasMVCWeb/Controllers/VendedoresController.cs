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
        private readonly ServicosVendedor _servicosvendedor;
        private readonly ServicosDepartamento _servicosdepartamento;

        public VendedoresController (ServicosVendedor servicosVendedor,ServicosDepartamento servicosDepartamento)
        {
            _servicosvendedor = servicosVendedor;
            _servicosdepartamento = servicosDepartamento;

        }


        public IActionResult Index()
        {
            var lista = _servicosvendedor.AcharTodos();
            return View(lista);
        }

        public IActionResult Create()
        {
            var departamentos = _servicosdepartamento.AcharTodos();
            var viewModel = new VendedoresViewModels { Departamentos = departamentos};
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor obj)
        {
            _servicosvendedor.Inserir(obj);
            return RedirectToAction(nameof (Index));
        }

    }
}