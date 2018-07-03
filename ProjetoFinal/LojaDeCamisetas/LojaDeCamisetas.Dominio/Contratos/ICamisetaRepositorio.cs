using LojaDeCamisetas.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDeCamisetas.Dominio.Contratos
{
    public interface ICamisetaRepositorio
    {
        Camiseta Adicionar(Camiseta camiseta);
        Camiseta Buscar(int id);
        List<Camiseta> BuscarTodos();
        Camiseta Atualizar(Camiseta camiseta);
        void Deletar(Camiseta camiseta);
    }
}
