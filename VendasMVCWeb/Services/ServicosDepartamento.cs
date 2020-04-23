using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasMVCWeb.Data;
using VendasMVCWeb.Models;

namespace VendasMVCWeb.Services
{
    public class ServicosDepartamento
    {
        private readonly VendasMVCWebContext _context;

        public ServicosDepartamento(VendasMVCWebContext context)
        {
            _context = context;
        }

        public List<Departamento> AcharTodos()
        {
            return _context.Departamento.OrderBy(x => x.Nome).ToList();
        }
    }
}
