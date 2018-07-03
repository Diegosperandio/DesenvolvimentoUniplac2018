using LojaDeCamisetas.Dominio.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDeCamisetas.Dominio.Entidade
{
    public class MarcaCamiseta
    {
        public MarcaCamiseta()
        {

        }

        public MarcaCamiseta(string nome)
        {
            this.Nome = nome;

            if (nome == null)
            {
                throw new BusinessException("Marca não registrada!");
            }
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", Nome);
        }
    }
}
