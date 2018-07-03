using LojaDeCamisetas.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDeCamisetas.Dominio.Contratos
{
    public interface IMarcaRepositorio
    {

        MarcaCamiseta Adicionar(MarcaCamiseta marcaCamiseta);

        MarcaCamiseta Buscar(int id);

        List<MarcaCamiseta> BuscarTodos();

        MarcaCamiseta Atualizar(MarcaCamiseta marcaCamiseta);

        void Deletar(MarcaCamiseta marcaCamiseta);

    }
}
