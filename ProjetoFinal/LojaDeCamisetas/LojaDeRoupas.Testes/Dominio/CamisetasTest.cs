using LojaDeCamisetas.Dominio.Exceptions;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LojaDeCamisetas.Dominio.Entidade;

namespace LojaDeRoupas.Testes.Dominio
{
    [TestClass]
    public class CamisetasTest
    {
        [TestMethod]
        public void Criar_Camiseta_Valida_Teste()
        {
            Camiseta camiseta = new Camiseta();
            camiseta.Tipo = TipoCamiseta.GolaV;
            camiseta.Tamanho = TamanhoCamiseta.PP;
            camiseta.Cor = "Vermelha";
            camiseta.Marca = new MarcaCamiseta();
            camiseta.Marca.Nome = "Adidas";
            camiseta.CodigoProduto = "123LF";
            camiseta.Tecido = "Algodão";
            camiseta.Preco = 103;

            Assert.AreEqual("GolaV - PP - Vermelha - Adidas - 123LF - Algodão - 103", camiseta.ToString());
        }

        [TestMethod]
        public void Criar_Marca_Valida_Teste()
        {
            MarcaCamiseta marca = new MarcaCamiseta();
            marca.Nome = "hahahaha";

            Assert.AreEqual("hahahaha", marca.ToString());
        }
    }
}
