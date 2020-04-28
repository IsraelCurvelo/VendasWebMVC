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

        public async Task<List<Vendedor>> AcharTodosAsync()
        {
            return await _context.Vendedor.ToListAsync();
        }

        public async Task InserirAsync(Vendedor vendedor)
        {

            _context.Add(vendedor);
            await _context.SaveChangesAsync();
        }

        public async Task<Vendedor> AcharPorIdAsync(int id)
        {
            return await  _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefaultAsync(vendedor => vendedor.Id == id);
        }

        public async Task RemoverAsync(int id)
        {
            var obj =await _context.Vendedor.FindAsync(id);
            _context.Vendedor.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Vendedor vendedor)
        {
            bool temUm = await _context.Vendedor.AnyAsync(x => x.Id == vendedor.Id);
            if (!temUm)
            {
                throw new NotFoundException("Id não encontrado");
            }
            try
            {
                _context.Update(vendedor);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
    }
}
