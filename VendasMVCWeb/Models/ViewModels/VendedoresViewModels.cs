using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasMVCWeb.Models.ViewModels
{
    public class VendedoresViewModels
    {
        public Vendedor Vendedor { get; set; }
        public ICollection<Departamento> Departamentos { get; set; }

    }
}
