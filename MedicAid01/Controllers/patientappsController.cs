using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MedicAid01.Models;

namespace doctorappoint.Controllers
{
    public class patientappsController : Controller
    {
        private newEntities3 db = new newEntities3();

        // GET: patientapps
        public ActionResult Index()
        {
            return View(db.patientapps.ToList());
        }

        // GET: patientapps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            patientapp patientapp = db.patientapps.Find(id);
            if (patientapp == null)
            {
                return HttpNotFound();
            }
            return View(patientapp);
        }

        // GET: patientapps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: patientapps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "patientId,patientName,Email,Description,Doctortype")] patientapp patientapp)
        {
            if (ModelState.IsValid)
            {
                db.patientapps.Add(patientapp);
                db.SaveChanges();
                return RedirectToAction("../patients1/home");
            }

            return View(patientapp);
        }

        // GET: patientapps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            patientapp patientapp = db.patientapps.Find(id);
            if (patientapp == null)
            {
                return HttpNotFound();
            }
            return View(patientapp);
        }

        // POST: patientapps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "patientId,patientName,Email,Description,Doctortype")] patientapp patientapp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patientapp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patientapp);
        }

        // GET: patientapps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            patientapp patientapp = db.patientapps.Find(id);
            if (patientapp == null)
            {
                return HttpNotFound();
            }
            return View(patientapp);
        }

        // POST: patientapps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            patientapp patientapp = db.patientapps.Find(id);
            db.patientapps.Remove(patientapp);
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
