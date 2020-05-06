using System;
using System.ComponentModel.DataAnnotations;
using VendasMVCWeb.Models.Enums;


namespace VendasMVCWeb.Models
{
    public class RegistroDeVendas
    {
        public int Id { get; set; }


        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Data da Venda")]
        [Required(ErrorMessage = "{0} obrigatório")]
        public DateTime Data { get; set; }

        [DisplayFormat(DataFormatString ="{0:F2}")]
        [Display(Name = "Valor da Venda")]
        [Required(ErrorMessage = "{0} obrigatório")]
        public double ValorTotal { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        public StatusDeVenda Status { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
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
