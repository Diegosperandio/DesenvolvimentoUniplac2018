using LojaDeCamisetas.Dominio.Entidade;
using LojaDeRoupas.Infraestrutura.Contexto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDeRoupas.Testes.Base
{
    public class CriarNovoBancoCamisetas<T> : DropCreateDatabaseAlways<CamisetasContext>
    {
        protected override void Seed(CamisetasContext context)
        {
            for (int i = 0; i < 10; i++)
            {
                //Criar camiseta
              
                Camiseta camiseta = new Camiseta(TipoCamiseta.MangaComprida, TamanhoCamiseta.M, "Verde", new MarcaCamiseta("Adidas"+i), "mj"+i, "Couro", 300, true);

                //Adicionar no contexto
                context.Camisetas.Add(camiseta);
            
            }

            //Salvar no contexto
            context.SaveChanges();

            base.Seed(context);
        }
    }

}
