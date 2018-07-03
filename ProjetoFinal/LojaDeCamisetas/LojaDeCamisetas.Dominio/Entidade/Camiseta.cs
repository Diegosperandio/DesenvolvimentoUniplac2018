using LojaDeCamisetas.Dominio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDeCamisetas.Dominio.Entidade
{
    public class Camiseta
    {

        public Camiseta()
        {

        }

        public Camiseta(TipoCamiseta tipo, TamanhoCamiseta tamanho, string cor, MarcaCamiseta marca,
                        string codigoProduto, string tecido, double preco, bool estaVendida)
        {
            this.Tipo = tipo;
            this.Tamanho = tamanho;
            this.Cor = cor;
            this.Marca = marca;
            this.CodigoProduto = codigoProduto;
            this.Tecido = tecido;
            this.Preco = preco;

            if (string.IsNullOrEmpty(cor.Trim()))
            {
                throw new BusinessException("Cor inválida!");
            }

            if (string.IsNullOrEmpty(codigoProduto.Trim()))
            {
                throw new BusinessException("Código do Produto inválido!");
            }

            if (preco <= 0)
            {
                throw new BusinessException("Preço não deve ser menor ou igual a zero!");
            }
        }

        public int Id { get; set; }

        public TipoCamiseta Tipo { get; set; }

        public TamanhoCamiseta Tamanho { get; set; }

        public string Cor { get; set; }

        public MarcaCamiseta Marca { get; set; }

        public string CodigoProduto { get; set; }

        public string Tecido { get; set; }

        public double Preco { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2} - {3} - {4} - {5} - {6}", Tipo, Tamanho, Cor, Marca, CodigoProduto, Tecido, Preco);
        }
    }
}
