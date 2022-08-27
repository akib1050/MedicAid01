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
    public class Patients1Controller : Controller
    {
        private newEntities3 db = new newEntities3();

        // GET: Patients
        public ActionResult Index()
        {
            return View(db.Patients.ToList());
        }


        public ActionResult home()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            if (Convert.ToString(Session["patient_email"]) == "")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public ActionResult LogIn(viewModel.PatientLogInViewModel patient)
        {
            if (ModelState.IsValid)
            {
                var pat = db.Patients.Where(a => a.Email.Equals(patient.Email) && a.Password.Equals(patient.Password)).FirstOrDefault();
                if (pat == null)
                {
                    ViewBag.NoPatient = "No Patients Found";
                    return View();
                }
                else
                {
                    //return Content("Log in Successful");
                    //  Session["patient_email"] = patient.Email;
                    //return RedirectToAction("../Home/Index");
                    return RedirectToAction("home");

                }
            }
            return View();
        }

       /* public ActionResult home()
        {
            string patinet_email = Convert.ToString(Session["patient_email"]);
            if (patinet_email == "")
            {
                return RedirectToAction("LogIn");
            }
            else
            {
                return View();
            }
            return View();
        }
*/
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("LogIn");
            //return View();
        }

        // GET: Patients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientId,PatientFirstName,PatientLastName,PatientPhoneNo,Email,Password,ConfirmPassword")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                var ptn = db.Patients.Where(a => a.Email.Equals(patient.Email)).FirstOrDefault();
                if (ptn != null)
                {
                    ViewBag.SameEmail = "This Email already exists ! \n Chose another email";
                }
                else
                {
                    db.Patients.Add(patient);
                    db.SaveChanges();
                    return RedirectToAction("LogIn");
                }
            }

            return View(patient);
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PatientId,PatientFirstName,PatientLastName,PatientPhoneNo,Email,Password")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
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
