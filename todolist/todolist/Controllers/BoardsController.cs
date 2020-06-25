using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BEUToDoList;
using BEUToDoList.Transactions;

namespace todolist.Controllers
{
    [Authorize]
    public class BoardsController : Controller
    {
        private Entities db = new Entities();

        // GET: Boards
        public ActionResult Index()
        {
            
            return View(BoardsBLL.List());
        }

        // GET: Boards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBoard tblBoard = BoardsBLL.Get(id);
            if (tblBoard == null)
            {
                return HttpNotFound();
            }
            return View(tblBoard);
        }

        // GET: Boards/Create
        public ActionResult Create()
        {
            ViewBag.id_owner = new SelectList(db.tblUser, "id_user", "first_name");
            return View();
        }

        // POST: Boards/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_board,name_board,id_owner,id_participants")] tblBoard tblBoard)
        {
            if (ModelState.IsValid)
            {
                BoardsBLL.Create(tblBoard);
                return RedirectToAction("Index");
            }

            ViewBag.id_owner = new SelectList(db.tblUser, "id_user", "first_name", tblBoard.id_owner);
            return View(tblBoard);
        }

        // GET: Boards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBoard tblBoard = BoardsBLL.Get(id);

            if (tblBoard == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_owner = new SelectList(db.tblUser, "id_user", "first_name", tblBoard.id_owner);
            return View(tblBoard);
        }

        // POST: Boards/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_board,name_board,id_owner,id_participants")] tblBoard tblBoard)
        {
            if (ModelState.IsValid)
            {
                BoardsBLL.Update(tblBoard);
                return RedirectToAction("Index");
            }
            ViewBag.id_owner = new SelectList(db.tblUser, "id_user", "first_name", tblBoard.id_owner);
            return View(tblBoard);
        }

        // GET: Boards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBoard tblBoard = BoardsBLL.Get(id);

            if (tblBoard == null)
            {
                return HttpNotFound();
            }
            return View(tblBoard);
        }

        // POST: Boards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BoardsBLL.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
