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

        public DbSet<VendasMVCWeb.Models.Departamento> Departamento { get; set; }
    }
}
