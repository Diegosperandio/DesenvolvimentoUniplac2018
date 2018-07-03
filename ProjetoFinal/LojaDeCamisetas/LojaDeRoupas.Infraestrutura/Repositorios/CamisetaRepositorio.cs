using LojaDeCamisetas.Dominio.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaDeCamisetas.Dominio.Entidade;
using LojaDeRoupas.Infraestrutura.Contexto;
using System.Data.Entity;

namespace LojaDeRoupas.Infraestrutura.Repositorios
{
    public class CamisetaRepositorio : ICamisetaRepositorio
    {
        private CamisetasContext _contexto;

        public CamisetaRepositorio()
        {
            _contexto = new CamisetasContext();
        }

        public Camiseta Adicionar(Camiseta camiseta)
        {
            var resultado = _contexto.Camisetas.Add(camiseta);
            _contexto.SaveChanges();
            return resultado;
        }

        public Camiseta Atualizar(Camiseta camiseta)
        {
            var entry = _contexto.Entry<Camiseta>(camiseta);
            entry.State = EntityState.Modified;
            _contexto.SaveChanges();

            return camiseta;
        }

        public Camiseta Buscar(int id)
        {
            return _contexto.Camisetas.Find(id);
        }

        public List<Camiseta> BuscarTodos()
        {
            return _contexto.Camisetas.Include("Marca").ToList();
        }

        public void Deletar(Camiseta camiseta)
        {
            var entry = _contexto.Entry<Camiseta>(camiseta);
            entry.State = EntityState.Deleted;
            _contexto.SaveChanges();
        }
    }
}
