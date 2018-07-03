using LojaDeCamisetas.Dominio.Contratos;
using LojaDeCamisetas.Dominio.Entidade;
using LojaDeRoupas.Infraestrutura.Contexto;
using LojaDeRoupas.Infraestrutura.Repositorios;
using LojaDeRoupas.Testes.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDeRoupas.Testes.Dados
{
    [TestClass]
    public class CamisetaDadosTeste
    {
        private CamisetasContext _contexto;
        private ICamisetaRepositorio _repositorio;

        [TestInitialize]
        public void Initialize()
        {
            Database.SetInitializer(new CriarNovoBancoCamisetas<CamisetasContext>());

            _contexto = new CamisetasContext();
            _repositorio = new CamisetaRepositorio();

            _contexto.Database.Initialize(true);

        }

        [TestCleanup]
        public void Clear()
        {

        }

        [TestMethod]
        public void DeveCadastrarCamiseta()
        {
            Camiseta camiseta = new Camiseta();
            
            _repositorio.Adicionar(camiseta);
            
            Camiseta novaCamiseta = _contexto.Camisetas.Find(camiseta.Id);
            
            Assert.IsTrue(novaCamiseta.Id > 0);
            Assert.AreEqual(camiseta.CodigoProduto, novaCamiseta.CodigoProduto);
            Assert.AreEqual(camiseta.Marca, novaCamiseta.Marca);

        }



        [TestMethod]
        public void CriarCamisetaTeste()
        {
            CamisetasContext contexto = new CamisetasContext();

            Camiseta camiseta = new Camiseta(TipoCamiseta.MangaComprida, TamanhoCamiseta.M, "Azul", new MarcaCamiseta("Nike"), "mj100", "algodão", 300, true);

            _repositorio.Adicionar(camiseta);

            contexto.SaveChanges();
            Camiseta novaCamiseta = _contexto.Camisetas.Find(camiseta.Id);
            Assert.IsTrue(novaCamiseta.Id > 0);
            //  Assert.AreEqual(novaCamiseta.Cpf, novoCliente.Cpf);
            // Assert.AreEqual(cliente.Endereco.Rua, novoCliente.Endereco.Rua);

        }

        [TestMethod]
        public void RetornarClientesTeste()
        {
            Camiseta camiseta = _repositorio.Buscar(1);

            Assert.IsNotNull(camiseta);

        }
        [TestMethod]
        public void RetornaTodosOsClientesRepositorioTeste()
        {
            List<Camiseta> camisetas = _repositorio.BuscarTodos();

            Assert.AreEqual(10, camisetas.Count);

        }

        [TestMethod]
        public void AtualizaRepositorioTeste()
        {
            Camiseta camiseta = _contexto.Camisetas.Find(1);

            camiseta.CodigoProduto = "jjk2";
            camiseta.Cor = "cinza";


            _repositorio.Atualizar(camiseta);


            Camiseta camisetaAtualizada = _contexto.Camisetas.Find(1);
            Assert.AreEqual("jjk2", camisetaAtualizada.CodigoProduto);
            Assert.AreEqual("cinza", camisetaAtualizada.Cor);

        }

        [TestMethod]
        public void DeletarClienteRepositorioTeste()
        {


            Camiseta camiseta = _repositorio.Buscar(1);

            _repositorio.Deletar(camiseta);

            Camiseta camistaDeletada = _contexto.Camisetas.Find(1);

            Assert.IsNull(camistaDeletada);


        }

    }
}
