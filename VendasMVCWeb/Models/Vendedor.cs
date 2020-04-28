using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace VendasMVCWeb.Models
{
    public class Vendedor
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="{0} obrigatório")]
        [StringLength(60,MinimumLength =3,ErrorMessage ="O {0} tem que ter entre {2} à {1} caracteres")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "{0} obrigatório")]
        [EmailAddress(ErrorMessage ="Digite um email válido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name= "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }


        [Required(ErrorMessage = "{0} obrigatório")]
        [Range(600,50000, ErrorMessage ="O {0} tem que estar entre {1} à {2}")]
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
