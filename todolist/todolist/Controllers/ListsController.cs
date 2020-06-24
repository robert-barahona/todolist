﻿using System;
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
    public class ListsController : Controller
    {
        private Entities db = new Entities();

        // GET: Lists
        public ActionResult Index()
        {
            var tblList = db.tblList.Include(t => t.tblBoard);
            return View(tblList.ToList());
        }

        // GET: Lists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblList tblList = db.tblList.Find(id);
            if (tblList == null)
            {
                return HttpNotFound();
            }
            return View(tblList);
        }

        // GET: Lists/Create
        public ActionResult Create()
        {
            ViewBag.id_board = new SelectList(db.tblBoard, "id_board", "name_board");
            return View();
        }

        // POST: Lists/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_list,name_list,id_board")] tblList tblList)
        {
            if (ModelState.IsValid)
            {
                db.tblList.Add(tblList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_board = new SelectList(db.tblBoard, "id_board", "name_board", tblList.id_board);
            return View(tblList);
        }

        // GET: Lists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblList tblList = db.tblList.Find(id);
            if (tblList == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_board = new SelectList(db.tblBoard, "id_board", "name_board", tblList.id_board);
            return View(tblList);
        }

        // POST: Lists/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_list,name_list,id_board")] tblList tblList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_board = new SelectList(db.tblBoard, "id_board", "name_board", tblList.id_board);
            return View(tblList);
        }

        // GET: Lists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblList tblList = db.tblList.Find(id);
            if (tblList == null)
            {
                return HttpNotFound();
            }
            return View(tblList);
        }

        // POST: Lists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblList tblList = db.tblList.Find(id);
            db.tblList.Remove(tblList);
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
