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
    public class MarcaDadosTeste
    {
        private CamisetasContext _contexto;
        private MarcaRepositorio _repositorio;




        [TestInitialize]
        public void Initialize()
        {
            Database.SetInitializer(new CriarNovoBancoCamisetas<CamisetasContext>());


            _contexto = new CamisetasContext();

            _repositorio = new MarcaRepositorio();

            _contexto.Database.Initialize(true);

            _contexto.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }
        [TestCleanup]
        public void Clear()
        {

        }


        [TestMethod]
        public void CriarMarcaTeste()
        {
            CamisetasContext contexto = new CamisetasContext();

            MarcaCamiseta marca = new MarcaCamiseta("Nike"
                                        );

            _repositorio.Adicionar(marca);

            contexto.SaveChanges();
            MarcaCamiseta novaMarca = _contexto.Marcas.Find(marca.Id);
            Assert.IsTrue(novaMarca.Id > 0);

        }

        [TestMethod]
        public void RetornarMarcasTeste()
        {
            MarcaCamiseta marca = _repositorio.Buscar(1);

            Assert.IsNotNull(marca);

        }


        [TestMethod]
        public void RetornaTodasAsMarcasRepositorioTeste()
        {
            List<MarcaCamiseta> Marcas = _repositorio.BuscarTodos();

            Assert.AreEqual(10, Marcas.Count);

        }

        [TestMethod]
        public void AtualizaRepositorioTeste()
        {
            MarcaCamiseta marca = _contexto.Marcas.Find(1);

            marca.Nome = "Adidas";



            _repositorio.Atualizar(marca);


            MarcaCamiseta marcaAtualizada = _contexto.Marcas.Find(1);
            Assert.AreEqual("Adidas", marcaAtualizada.Nome);

        }

        [TestMethod]
        public void DeletarMarcaRepositorioTeste()
        {

            //MarcaCamiseta marca = _repositorio.Buscar(1);

            //_repositorio.Deletar(marca);

            //MarcaCamiseta marcaDeletada = _contexto.Marcas.Find(1);

            //Assert.IsNull(marcaDeletada);


        }
    }
}
