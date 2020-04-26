using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasMVCWeb.Models;
using Microsoft.EntityFrameworkCore;
using VendasMVCWeb.Services.Exceptions;

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

            _context.Add(vendedor);
            _context.SaveChanges();
        }

        public Vendedor AcharPorId(int id)
        {
            return _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefault(vendedor => vendedor.Id == id);
        }

        public void Remover(int id)
        {
            var obj = _context.Vendedor.Find(id);
            _context.Vendedor.Remove(obj);
            _context.SaveChanges();
        }

        public void Atualizar(Vendedor vendedor)
        {
            if (!_context.Vendedor.Any(x => x.Id == vendedor.Id))
            {
                throw new NotFoundException("Id não encontrado");
            }
            try
            {
                _context.Update(vendedor);
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
