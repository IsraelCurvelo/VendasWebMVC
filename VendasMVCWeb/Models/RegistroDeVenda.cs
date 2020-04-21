using System;
using VendasMVCWeb.Models.Enums;


namespace VendasMVCWeb.Models
{
    public class RegistroDeVenda
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double ValorTotal { get; set; }
        public StatusDeVenda Status { get; set; }
        public Vendedor Vendedor { get; set; }

        public RegistroDeVenda()
        {
        }

        public RegistroDeVenda(int id, DateTime data, double valorTotal, StatusDeVenda status, Vendedor vendedor)
        {
            Id = id;
            Data = data;
            ValorTotal = valorTotal;
            Status = status;
            Vendedor = vendedor;
        }
    }
}
