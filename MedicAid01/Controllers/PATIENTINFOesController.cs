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
    public class PATIENTINFOesController : Controller
    {
        private newEntities3 db = new newEntities3();

        // GET: PATIENTINFOes
        public ActionResult Index()
        {
            var pATIENTINFOes = db.PATIENTINFOes.Include(p => p.Patient);
            return View(pATIENTINFOes.ToList());
        }

        // GET: PATIENTINFOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PATIENTINFO pATIENTINFO = db.PATIENTINFOes.Find(id);
            if (pATIENTINFO == null)
            {
                return HttpNotFound();
            }
            return View(pATIENTINFO);
        }

        // GET: PATIENTINFOes/Create
        public ActionResult Create()
        {
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "PatientFirstName");
            return View();
        }

        // POST: PATIENTINFOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientInfoId,PatientFirstName,PatientLastName,Age,Weight,Gender,MedicalHistory,BloodGrp,PatientId")] PATIENTINFO pATIENTINFO)
        {
            if (ModelState.IsValid)
            {
                db.PATIENTINFOes.Add(pATIENTINFO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "PatientFirstName", pATIENTINFO.PatientId);
            return View(pATIENTINFO);
        }

        // GET: PATIENTINFOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PATIENTINFO pATIENTINFO = db.PATIENTINFOes.Find(id);
            if (pATIENTINFO == null)
            {
                return HttpNotFound();
            }
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "PatientFirstName", pATIENTINFO.PatientId);
            return View(pATIENTINFO);
        }

        // POST: PATIENTINFOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PatientInfoId,PatientFirstName,PatientLastName,Age,Weight,Gender,MedicalHistory,BloodGrp,PatientId")] PATIENTINFO pATIENTINFO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pATIENTINFO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "PatientFirstName", pATIENTINFO.PatientId);
            return View(pATIENTINFO);
        }

        // GET: PATIENTINFOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PATIENTINFO pATIENTINFO = db.PATIENTINFOes.Find(id);
            if (pATIENTINFO == null)
            {
                return HttpNotFound();
            }
            return View(pATIENTINFO);
        }

        // POST: PATIENTINFOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PATIENTINFO pATIENTINFO = db.PATIENTINFOes.Find(id);
            db.PATIENTINFOes.Remove(pATIENTINFO);
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
