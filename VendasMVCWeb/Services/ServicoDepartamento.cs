using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasMVCWeb.Models;

namespace VendasMVCWeb.Services
{
    public class ServicoDepartamento
    {
        private readonly VendasMVCWebContext _context;

        public ServicoDepartamento(VendasMVCWebContext context)
        {
            _context = context;
        }

        public async Task<List<Departamento>> AcharTodosAsync()
        {
            return await _context.Departamento.OrderBy(x => x.Nome).ToListAsync();
        }
    }
}
