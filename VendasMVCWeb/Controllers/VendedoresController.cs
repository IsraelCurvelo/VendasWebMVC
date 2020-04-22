using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasMVCWeb.Models;
using VendasMVCWeb.Services;

namespace VendasMVCWeb.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly ServicosVendedor _servicosvendedor;

        public VendedoresController (ServicosVendedor servicosVendedor)
        {
            _servicosvendedor = servicosVendedor;
        }


        public IActionResult Index()
        {
            var lista = _servicosvendedor.AcharTodos();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
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