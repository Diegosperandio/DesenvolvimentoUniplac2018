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
    public class MarcaCamisetasController : Controller
    {
        private MarcaRepositorio repositorio = new MarcaRepositorio();

        // GET: MarcaCamisetas
        public ActionResult Index()
        {
            return View(repositorio.BuscarTodos());
        }

        // GET: MarcaCamisetas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarcaCamiseta marcaCamiseta = repositorio.Buscar((int)id);
            if (marcaCamiseta == null)
            {
                return HttpNotFound();
            }
            return View(marcaCamiseta);
        }

        // GET: MarcaCamisetas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MarcaCamisetas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] MarcaCamiseta marcaCamiseta)
        {
            if (ModelState.IsValid)
            {
                repositorio.Adicionar(marcaCamiseta);
                return RedirectToAction("Index");
            }

            return View(marcaCamiseta);
        }

        // GET: MarcaCamisetas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarcaCamiseta marcaCamiseta = repositorio.Buscar((int)id);
            if (marcaCamiseta == null)
            {
                return HttpNotFound();
            }
            return View(marcaCamiseta);
        }

        // POST: MarcaCamisetas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] MarcaCamiseta marcaCamiseta)
        {
            if (ModelState.IsValid)
            {
                repositorio.Atualizar(marcaCamiseta);
                return RedirectToAction("Index");
            }
            return View(marcaCamiseta);
        }

        // GET: MarcaCamisetas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarcaCamiseta marcaCamiseta = repositorio.Buscar((int)id);
            if (marcaCamiseta == null)
            {
                return HttpNotFound();
            }
            return View(marcaCamiseta);
        }

        // POST: MarcaCamisetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MarcaCamiseta marcaCamiseta = repositorio.Buscar((int)id);
            repositorio.Deletar(marcaCamiseta);            
            return RedirectToAction("Index");
        }

    }
}
