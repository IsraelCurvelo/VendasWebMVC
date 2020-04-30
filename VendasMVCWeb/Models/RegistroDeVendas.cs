using System;
using System.ComponentModel.DataAnnotations;
using VendasMVCWeb.Models.Enums;


namespace VendasMVCWeb.Models
{
    public class RegistroDeVendas
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime Data { get; set; }

        [DisplayFormat(DataFormatString ="{0:F2}")]
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
