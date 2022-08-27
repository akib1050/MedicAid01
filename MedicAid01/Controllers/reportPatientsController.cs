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
    public class reportPatientsController : Controller
    {
        private newEntities3 db = new newEntities3();

        // GET: reportPatients
        public ActionResult Index()
        {
            var reportPatients = db.reportPatients.Include(r => r.Doctor).Include(r => r.Patient);
            return View(reportPatients.ToList());
        }

        // GET: reportPatients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reportPatient reportPatient = db.reportPatients.Find(id);
            if (reportPatient == null)
            {
                return HttpNotFound();
            }
            return View(reportPatient);
        }

        // GET: reportPatients/Create
        public ActionResult Create()
        {
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "DoctorFirstName");
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "PatientFirstName");
            return View();
        }

        // POST: reportPatients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReportId,Symptom,Diagnosis,PrescribedMedicine,DoctorId,PatientId")] reportPatient reportPatient)
        {
            if (ModelState.IsValid)
            {
                db.reportPatients.Add(reportPatient);
                db.SaveChanges();
                return RedirectToAction("../PATIENTINFOes/Index");
            }

            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "DoctorFirstName", reportPatient.DoctorId);
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "PatientFirstName", reportPatient.PatientId);
            return View(reportPatient);
        }

        // GET: reportPatients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reportPatient reportPatient = db.reportPatients.Find(id);
            if (reportPatient == null)
            {
                return HttpNotFound();
            }
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "DoctorFirstName", reportPatient.DoctorId);
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "PatientFirstName", reportPatient.PatientId);
            return View(reportPatient);
        }

        // POST: reportPatients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReportId,Symptom,Diagnosis,PrescribedMedicine,DoctorId,PatientId")] reportPatient reportPatient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reportPatient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorId = new SelectList(db.Doctors, "DoctorId", "DoctorFirstName", reportPatient.DoctorId);
            ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "PatientFirstName", reportPatient.PatientId);
            return View(reportPatient);
        }

        // GET: reportPatients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reportPatient reportPatient = db.reportPatients.Find(id);
            if (reportPatient == null)
            {
                return HttpNotFound();
            }
            return View(reportPatient);
        }

        // POST: reportPatients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            reportPatient reportPatient = db.reportPatients.Find(id);
            db.reportPatients.Remove(reportPatient);
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
