using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VendasMVCWeb.Services;

namespace VendasMVCWeb.Controllers
{
    public class RegistroDeVendasController : Controller
    {
        private readonly ServicoRegistroDeVendas _servicoRegistroDeVendas;

        public RegistroDeVendasController(ServicoRegistroDeVendas servicoRegistroDeVendas)
        {
            _servicoRegistroDeVendas = servicoRegistroDeVendas;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> BuscaSimples(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var resultado = await _servicoRegistroDeVendas.AcharPorDataAsync(minDate, maxDate);
            return View(resultado);
        }

        public IActionResult BuscaAgrupada()
        {
            return View();
        }
    }
}