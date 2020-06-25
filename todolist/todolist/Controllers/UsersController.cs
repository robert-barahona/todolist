using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BEUToDoList;
using BEUToDoList.Transactions;
using todolist.Models;

namespace todolist.Controllers
{
    public class UsersController : Controller
    {
        private Entities db = new Entities();

        // GET: Users
        public ActionResult Index()
        {
            return View(UsersBLL.List());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUser tblUser = UsersBLL.Get(id);
            if (tblUser == null)
            {
                return HttpNotFound();
            }
            return View(tblUser);
        }

        // GET: Users/Create
        public ActionResult Register()
        {
            return View();
        }

        // Redirigir pagina cuando termina el registro
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "id_user,first_name,last_name,email,pass")] tblUser tblUser)
        {
            if (ModelState.IsValid)
            {
                UsersBLL.Create(tblUser);
                return RedirectToAction("Index", "Boards");
            }

            return View(tblUser);
        }

        //Iniciar Sesión
        public ActionResult Login()
        {
            return View();
        }

        //Verifico las credenciales de inicio de sesión
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin login)
        {
            string message = "";
            //Verifico si no hay campos vacíos
            if (!string.IsNullOrEmpty(login.email) && !string.IsNullOrEmpty(login.password))
            {
                tblUser user = UsersBLL.GetUser(login.email, login.password);
                //Verifico si se encontró un usuario en la base de datos
                if (user == null)
                {
                    message = "No encontramos tus datos";
                }
                else
                {
                    //encontramos un usario y almacenamos una cookie con su email
                    FormsAuthentication.SetAuthCookie(user.email, true);
                    return RedirectToAction("Index", "Boards");
                }
            }
            else
            {
                message = "Llena los campos para inicar sesión";
            }
            ViewBag.Message = message;
            return View();
        }

        //cerrar sesión
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        
        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUser tblUser = UsersBLL.Get(id);
            if (tblUser == null)
            {
                return HttpNotFound();
            }
            return View(tblUser);
        }

        // POST: Users/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_user,first_name,last_name,email,pass")] tblUser tblUser)
        {
            if (ModelState.IsValid)
            {
                UsersBLL.Update(tblUser);
                return RedirectToAction("Index");
            }
            return View(tblUser);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUser tblUser = UsersBLL.Get(id);
            if (tblUser == null)
            {
                return HttpNotFound();
            }
            return View(tblUser);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsersBLL.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
