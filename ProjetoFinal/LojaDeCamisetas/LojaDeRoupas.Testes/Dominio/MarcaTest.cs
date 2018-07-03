using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LojaDeCamisetas.Dominio.Exceptions;
using LojaDeCamisetas.Dominio.Entidade;

namespace LojaDeRoupas.Testes.Dominio
{
    [TestClass]
    public class MarcaTest
    {
        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void Criar_Marca_Invalida_Teste()
        {
            MarcaCamiseta marca = new MarcaCamiseta(null);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void Criar_CorInvalida_Teste()
        {
            MarcaCamiseta marca = new MarcaCamiseta("Bilabong");

            Camiseta camiseta = new Camiseta(TipoCamiseta.GolaV,
                                             TamanhoCamiseta.P,
                                             string.Empty,
                                             marca,
                                             "12345",
                                             "algodão",
                                             90,
                                             true);
        }
    }
}
