using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasMVCWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace VendasMVCWeb.Services
{
    public class ServicoRegistroDeVendas
    {
        private readonly VendasMVCWebContext _context;

        public ServicoRegistroDeVendas(VendasMVCWebContext context)
        {
            _context = context;
        }

        public async Task<List<RegistroDeVendas>> AcharPorDataAsync(DateTime? inicio, DateTime? final)
        {
            var resultado = from obj in _context.RegistroDeVendas select obj;
            if (inicio.HasValue)
            {
                resultado = resultado.Where(x => x.Data >= inicio.Value);
            }
            if (final.HasValue)
            {
                resultado = resultado.Where(x => x.Data <= final.Value);

            }
            return await resultado
                .Include(x=> x.Vendedor)
                .Include(x => x.Vendedor.Departamento)
                .OrderByDescending(x => x.Data)                
                .ToListAsync();
        }

        public async Task<List<IGrouping<Departamento,RegistroDeVendas>>> AcharGrupoPorDataAsync(DateTime? inicio, DateTime? final)
        {
            var resultado = from obj in _context.RegistroDeVendas select obj;
            if (inicio.HasValue)
            {
                resultado = resultado.Where(x => x.Data >= inicio.Value);
            }
            if (final.HasValue)
            {
                resultado = resultado.Where(x => x.Data <= final.Value);

            }
            return await resultado
                .Include(x => x.Vendedor)
                .Include(x => x.Vendedor.Departamento)
                .OrderByDescending(x => x.Data)
                .GroupBy(x => x.Vendedor.Departamento)
                .ToListAsync();
        }

    }
}
