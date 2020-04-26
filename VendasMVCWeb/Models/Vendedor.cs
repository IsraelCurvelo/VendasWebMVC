using System;
using System.Collections.Generic;
using System.Linq;

namespace VendasMVCWeb.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public double SalarioBase { get; set; }
        public Departamento Departamento { get; set; }
        public int DepartamentoId { get; set; }
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
