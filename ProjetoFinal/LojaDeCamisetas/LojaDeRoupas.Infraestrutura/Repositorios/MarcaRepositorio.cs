using LojaDeCamisetas.Dominio.Contratos;
using LojaDeRoupas.Infraestrutura.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaDeCamisetas.Dominio.Entidade;
using System.Data.Entity;

namespace LojaDeRoupas.Infraestrutura.Repositorios
{
    public class MarcaRepositorio: IMarcaRepositorio
    {


        private CamisetasContext _contexto;

        public MarcaRepositorio()
        {
            _contexto = new CamisetasContext();
        }

        public MarcaCamiseta Adicionar(MarcaCamiseta marcaCamiseta)
        {
            var resultado = _contexto.Marcas.Add(marcaCamiseta);
            _contexto.SaveChanges();
            return resultado;
        }

        public MarcaCamiseta Atualizar(MarcaCamiseta marcaCamiseta)
        {
            var entry = _contexto.Entry<MarcaCamiseta>(marcaCamiseta);
            entry.State = EntityState.Modified;
            _contexto.SaveChanges();
            return marcaCamiseta;
        }

        public MarcaCamiseta Buscar(int id)
        {
            return _contexto.Marcas.Find(id); ;
        }

        public List<MarcaCamiseta> BuscarTodos()
        {
            return _contexto.Marcas.ToList();
        }

        public void Deletar(MarcaCamiseta marcaCamiseta)
        {
            var entry = _contexto.Entry<MarcaCamiseta>(marcaCamiseta);
            entry.State = EntityState.Deleted;
            _contexto.SaveChanges();
        }
    }
}
