using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MedicAid01.Models;

namespace MedicAid01.Controllers
{
    public class Administrators1Controller : Controller
    {
        private newEntities3 db = new newEntities3();


        // GET: Administrators
        public ActionResult Index()
        {
            return View(db.Administrators.ToList());
        }



        [HttpGet]
        public ActionResult LogIn()
        {
            if (Convert.ToString(Session["admin_email"]) == "")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult LogIn(viewModel.AdminLogInViewModel admin)
        {
            if (ModelState.IsValid)
            {
                var admn = db.Administrators.Where(a => a.Email.Equals(admin.Email) && a.Password.Equals(admin.Password)).FirstOrDefault();
                if (admn == null)
                {
                    ViewBag.NoAdmin = "No Admin Found";
                    return View();
                }
                else
                { 
                    Session["admin_email"] = admin.Email;
                    return RedirectToAction("../Patients1/Index");
                }
            }
            return View();
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("LogIn");
            //return View();
        }

        // GET: Administrators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrator administrator = db.Administrators.Find(id);
            if (administrator == null)
            {
                return HttpNotFound();
            }
            return View(administrator);
        }

        // GET: Administrators/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Administrators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdminId,AdminFirstName,AdminLastName,AdminPhoneNo,Email,Password,ConfirmPassword")] Administrator administrator)
        {
            if (ModelState.IsValid)
            {
                var admn = db.Administrators.Where(a => a.Email.Equals(administrator.Email)).FirstOrDefault();
                if (admn != null)
                {
                    ViewBag.SameEmail = "This Email already exists ! \n Chose another email";
                }
                else
                {
                    db.Administrators.Add(administrator);
                    db.SaveChanges();
                    return RedirectToAction("LogIn");
                }
            }

            return View(administrator);
        }

      
        // GET: Administrators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Administrator administrator = db.Administrators.Find(id);
            if (administrator == null)
            {
                return HttpNotFound();
            }
            return View(administrator);
        }

        // POST: Administrators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Administrator administrator = db.Administrators.Find(id);
            db.Administrators.Remove(administrator);
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
