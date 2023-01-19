using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GradPlus.Data.Models.Domain;
using GradPlus.Data.Repository;
using GradPlus.Services.IServices;
using GradPlus.Services.Services;

namespace GradPlus.Controllers
{
    public class EmployerController : Controller
    {
        private GradPlusContext db = new GradPlusContext();
        private IJobServices jobServices;
        private IUserServices userServices;


        public EmployerController()
        {
            jobServices = new JobServices();
            userServices = new UserServices();
        }

        // GET: Employer
        public ActionResult GetAllEmployers()
        {
            return View(userServices.GetEmployers());
        }

        // GET: Employer/Details/5
        public ActionResult GetEmployer(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employer employer = userServices.GetEmployer(id);
            if (employer == null)
            {
                return HttpNotFound();
            }
            return View(employer);
        }

        // GET: Employer/Details/5
        public ActionResult GetEmployerJobs(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var jobs = jobServices.GetEmployerJobs(id);
            if (jobs == null)
            {
                return HttpNotFound();
            }
            return View(jobs);
        }


        // GET: Employer/Details/5
        public ActionResult GetEmployerDashboard()
        {
           
            return View();
        }



        //// GET: Employer/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Employer/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,IdentityID,Email,Profile_Img,CompanyName,CompanyDescription,Website,EmployeeCount,YearFounded")] Employer employer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Users.Add(employer);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(employer);
        //}

        //// GET: Employer/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Employer employer = db.Users.Find(id);
        //    if (employer == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(employer);
        //}

        // POST: Employer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "ID,IdentityID,Email,Profile_Img,CompanyName,CompanyDescription,Website,EmployeeCount,YearFounded")] Employer employer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(employer).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(employer);
        //}

        //// GET: Employer/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Employer employer = db.Users.Find(id);
        //    if (employer == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(employer);
        //}

        // POST: Employer/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Employer employer = db.Users.Find(id);
        //    db.Users.Remove(employer);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
