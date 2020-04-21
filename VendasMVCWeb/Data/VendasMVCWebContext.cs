using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VendasMVCWeb.Models;

namespace VendasMVCWeb.Data
{
    public class VendasMVCWebContext : DbContext
    {
        public VendasMVCWebContext (DbContextOptions<VendasMVCWebContext> options)
            : base(options)
        {
        }

        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<RegistroDeVenda> RegistroDeVendas { get; set; }
    }
}
