using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LojaDeCamisetas.Dominio.Entidade;
using LojaDeRoupas.Infraestrutura.Contexto;
using LojaDeRoupas.Infraestrutura.Repositorios;

namespace LojaDeCamisatas.ApresentaçãoWeb.Controllers
{
    public class CamisetasController : Controller
    {
        private CamisetaRepositorio repositorio = new CamisetaRepositorio();

        // GET: Camisetas
        public ActionResult Index()
        {
            return View(repositorio.BuscarTodos());
        }

        // GET: Camisetas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camiseta camiseta = repositorio.Buscar((int) id);
            if (camiseta == null)
            {
                return HttpNotFound();
            }
            return View(camiseta);
        }

        // GET: Camisetas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Camisetas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tipo,Tamanho,Cor,CodigoProduto,Tecido,Preco")] Camiseta camiseta)
        {
            if (ModelState.IsValid)
            {
                repositorio.Adicionar(camiseta);
                return RedirectToAction("Index");
            }

            return View(camiseta);
        }

        // GET: Camisetas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camiseta camiseta = repositorio.Buscar((int)id);
            if (camiseta == null)
            {
                return HttpNotFound();
            }
            return View(camiseta);
        }

        // POST: Camisetas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tipo,Tamanho,Cor,CodigoProduto,Tecido,Preco")] Camiseta camiseta)
        {
            if (ModelState.IsValid)
            {
                repositorio.Atualizar(camiseta);
                
                return RedirectToAction("Index");
            }
            return View(camiseta);
        }

        // GET: Camisetas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Camiseta camiseta = repositorio.Buscar((int)id);
            if (camiseta == null)
            {
                return HttpNotFound();
            }
            return View(camiseta);
        }

        // POST: Camisetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Camiseta camiseta = repositorio.Buscar((int)id);
            repositorio.Deletar(camiseta);
            return RedirectToAction("Index");
        }

    }
}
