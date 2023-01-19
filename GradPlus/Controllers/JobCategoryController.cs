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
    public class JobCategoryController : Controller
    {
        private GradPlusContext db = new GradPlusContext();
        private IJobServices jobServices;
        private IUserServices userServices;

        public JobCategoryController()
        {
            jobServices = new JobServices();
            userServices = new UserServices();
        }

        // GET: JobCategory
        public ActionResult GetJobCategories()
        {
            return View(jobServices.GetJobCategories());
        }

        // GET: JobCategory/Details/5
        public ActionResult GetJobCategoryDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobCategory jobCategory = jobServices.GetJobCategory(id);
            if (jobCategory == null)
            {
                return HttpNotFound();
            }
            return View(jobCategory);
        }

        // GET: JobCategory/Create
        public ActionResult CreateJobCategory()
        {
            return View();
        }

        // POST: JobCategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateJobCategory([Bind(Include = "ID,Name,Description")] JobCategory jobCategory)
        {
            if (ModelState.IsValid)
            {
                jobServices.CreateJobCategory(jobCategory);
                return RedirectToAction("GetJobCategories");
            }

            return View(jobCategory);
        }

        // GET: JobCategory/Edit/5
        public ActionResult EditJobCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobCategory jobCategory = jobServices.GetJobCategory(id);
            if (jobCategory == null)
            {
                return HttpNotFound();
            }
            return View(jobCategory);
        }

        // POST: JobCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditJobCategory([Bind(Include = "ID,Name,Description")] JobCategory jobCategory)
        {
            if (ModelState.IsValid)
            {
                jobServices.EditJobCategory(jobCategory, jobCategory.ID);
                return RedirectToAction("GetJobCategories");
            }
            return View(jobCategory);
        }

        // GET: JobCategory/Delete/5
        public ActionResult DeleteJobCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobCategory jobCategory = jobServices.GetJobCategory(id);
            if (jobCategory == null)
            {
                return HttpNotFound();
            }
            return View(jobCategory);
        }

        // POST: JobCategory/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteJobCategory(int id)
        {
            jobServices.DeleteJobCategory(id);
            return RedirectToAction("GetJobCategories");
        }

        public ActionResult GetCategoryJobs(int id)
        { 
            var jobs = jobServices.GetJobCategoryJobs(id);
            return View(jobs);
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
