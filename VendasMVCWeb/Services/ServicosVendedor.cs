﻿using System;
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
           
            _context.Add(vendedor);
            _context.SaveChanges();
        }

        public Vendedor AcharPorId(int id)
        {
            return _context.Vendedor.FirstOrDefault(vendedor => vendedor.Id == id);
        }

        public void Remover(int id)
        {
            var obj = _context.Vendedor.Find(id);
            _context.Vendedor.Remove(obj);
            _context.SaveChanges();
        }
    }
}
