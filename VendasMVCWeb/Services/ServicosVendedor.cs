using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasMVCWeb.Models;


namespace VendasMVCWeb.Services
{
    public class ServicosVendedor
    {
        private readonly VendasMVCWebContext _context;

        public ServicosVendedor(VendasMVCWebContext context)
        {
            _context = context;
        }

        public List<Vendedor> AcharTodos()
        {
            return _context.Vendedor.ToList();
        }

        public void Inserir(Vendedor vendedor)
        {
            //obj.Departamento = _context.Departamento.First();
            _context.Add(vendedor);
            _context.SaveChanges();
        }
    }
}
