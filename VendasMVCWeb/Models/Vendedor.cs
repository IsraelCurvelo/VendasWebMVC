using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace VendasMVCWeb.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name= "Data de Nascimento")]
        [DataType(DataType.Date)]
       // [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime DataNascimento { get; set; }

        [Display(Name="Salário")]
        [DisplayFormat(DataFormatString ="{0:F2}")]
        public double SalarioBase { get; set; }        

        [Display(Name="Departamento")]
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
        public ICollection<RegistroDeVenda> Vendas { get; set; } = new List<RegistroDeVenda>();

        public Vendedor()
        {
        }

        public Vendedor(int id, string nome, string email, DateTime dataNascimento, double salarioBase, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            SalarioBase = salarioBase;
            Departamento = departamento;
        }

        public void AdicionarVenda(RegistroDeVenda venda)
        {
            Vendas.Add(venda);
        }

        public void RemoverVenda(RegistroDeVenda venda)
        {
            Vendas.Remove(venda);
        }

        public double TotalDeVendas(DateTime inicial,DateTime final)
        {
            return Vendas.Where(vendas => vendas.Data >= inicial && vendas.Data <= final).Sum(vendas => vendas.ValorTotal);
                }
    }
}
