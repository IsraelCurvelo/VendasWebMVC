using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasMVCWeb.Models;
using VendasMVCWeb.Models.ViewModels;
using VendasMVCWeb.Services;
using VendasMVCWeb.Services.Exceptions;

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


        public async Task<IActionResult> Index()
        {
            var lista = await _servicosVendedor.AcharTodosAsync();
            return View(lista);
        }

        public async Task<IActionResult> Create()
        {
            var departamentos = await _servicoDepartamento.AcharTodosAsync();
            var viewModel = new VendedorFormViewModel { Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                var departmentos = await _servicoDepartamento.AcharTodosAsync();
                var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departmentos };
                return View(viewModel);

            }

            await _servicosVendedor.InserirAsync(vendedor);
            return RedirectToAction(nameof (Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            var obj =await _servicosVendedor.AcharPorIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _servicosVendedor.RemoverAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            var obj = await _servicosVendedor.AcharPorIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _servicosVendedor.AcharPorIdAsync(id.Value);
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            List<Departamento> departamentos =await _servicoDepartamento.AcharTodosAsync();
            VendedorFormViewModel viewModel = new VendedorFormViewModel { Vendedor = obj, Departamentos = departamentos };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                var departmentos = await _servicoDepartamento.AcharTodosAsync();
                var viewModel = new VendedorFormViewModel { Vendedor = vendedor, Departamentos = departmentos };
                return View(viewModel);

            }

            if (id != vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não corresponde" });
            }

            try
            {
                await _servicosVendedor.AtualizarAsync(vendedor);
                return RedirectToAction(nameof(Index));

            }
            catch(ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message});
            }

        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }

    }
}