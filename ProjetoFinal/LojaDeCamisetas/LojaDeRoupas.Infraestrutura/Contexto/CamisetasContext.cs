using LojaDeCamisetas.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDeRoupas.Infraestrutura.Contexto
{
    public class CamisetasContext: DbContext
    {
        public CamisetasContext()
            :base("CamisetasDB")
        {

        }

        public DbSet<Camiseta> Camisetas { get; set; }
        public DbSet<MarcaCamiseta> Marcas { get; set; }
    }
}
