using System;
using VendasMVCWeb.Models.Enums;


namespace VendasMVCWeb.Models
{
    public class RegistroDeVendas
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double ValorTotal { get; set; }
        public StatusDeVenda Status { get; set; }
        public Vendedor Vendedor { get; set; }

        public RegistroDeVendas()
        {
        }

        public RegistroDeVendas(int id, DateTime data, double valorTotal, StatusDeVenda status, Vendedor vendedor)
        {
            Id = id;
            Data = data;
            ValorTotal = valorTotal;
            Status = status;
            Vendedor = vendedor;
        }
    }
}
