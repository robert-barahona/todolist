using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BEUToDoList;

namespace todolist.Controllers
{
    public class TasksController : Controller
    {
        private Entities db = new Entities();

        // GET: Tasks
        public ActionResult Index()
        {
            var tblTask = db.tblTask.Include(t => t.tblList);
            return View(tblTask.ToList());
        }

        // GET: Tasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTask tblTask = db.tblTask.Find(id);
            if (tblTask == null)
            {
                return HttpNotFound();
            }
            return View(tblTask);
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            ViewBag.id_list = new SelectList(db.tblList, "id_list", "name_list");
            return View();
        }

        // POST: Tasks/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_task,title,descr,asigned_to,id_list")] tblTask tblTask)
        {
            if (ModelState.IsValid)
            {
                db.tblTask.Add(tblTask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_list = new SelectList(db.tblList, "id_list", "name_list", tblTask.id_list);
            return View(tblTask);
        }

        // GET: Tasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTask tblTask = db.tblTask.Find(id);
            if (tblTask == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_list = new SelectList(db.tblList, "id_list", "name_list", tblTask.id_list);
            return View(tblTask);
        }

        // POST: Tasks/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_task,title,descr,asigned_to,id_list")] tblTask tblTask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblTask).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_list = new SelectList(db.tblList, "id_list", "name_list", tblTask.id_list);
            return View(tblTask);
        }

        // GET: Tasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblTask tblTask = db.tblTask.Find(id);
            if (tblTask == null)
            {
                return HttpNotFound();
            }
            return View(tblTask);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblTask tblTask = db.tblTask.Find(id);
            db.tblTask.Remove(tblTask);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
