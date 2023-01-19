using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GradPlus.Data.Models.Domain;
using GradPlus.Data.Repository;
using GradPlus.Models;
using GradPlus.Services.IServices;
using GradPlus.Services.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

namespace GradPlus.Controllers
{
    public class JobController : Controller
    {
        private GradPlusContext db = new GradPlusContext();
        private IJobServices jobServices;
        private IUserServices userServices;
        private Helper helper;


        public JobController()
        {
            jobServices = new JobServices();
            userServices = new UserServices();
            helper = new Helper();
        }
        // GET: Job
        public ActionResult GetJobs()
        {
            List<Job> list;

            var jobs = jobServices.GetJobs();

            if(User.IsInRole("Employer")){
                list = jobs.Where(x => x.EmployerId == User.Identity.GetUserId()).ToList();
            }
            else
            {
                list = jobs.ToList();
            }
            return View(list);
        }



        // GET: Job/Details/5
        public ActionResult GetJob(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = jobServices.GetJob(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: Job/Create
        public ActionResult CreateJob()
        {
            var categories = jobServices.GetJobCategories();

            ViewBag.Categories = categories;
            return View();
        }

        // POST: Job/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateJob([Bind(Include = "ID,JobTitle,Location,Description,Salary,CompanyName,ComapanyEmail,CompanyWebsite,CompanyAddress,JobCategoryId,EmployerId")] Job job)
        {
            if (ModelState.IsValid)
            {
                job.EmployerId = User.Identity.GetUserId();
                jobServices.PostJob(job);
                return RedirectToAction("GetJobs");
            }

            return View(job);
        }

      


        // GET: Job/Edit/5
        public ActionResult EditJob(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = jobServices.GetJob(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Job/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditJob([Bind(Include = "ID,JobTitle,Location,Description,Salary,CompanyName,ComapanyEmail,CompanyWebsite,CompanyAddress")] Job job)
        {
            if (ModelState.IsValid)
            {
                jobServices.EditJob(job, job.ID);
                return RedirectToAction("GetJobs");
            }
            return View(job);
        }

        // GET: Job/Delete/5
        public ActionResult DeleteJob(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = jobServices.GetJob(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Job/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteJob(int id)
        {
            jobServices.DeleteJob(id);
            return RedirectToAction("GetJobs");
        }

        [HttpPost]
        public ActionResult ShowSearchResults(string SearchString)
        {
            if (SearchString == null)
            {
                return View();
            }
            return View(jobServices.SearchJobs(SearchString));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult SaveJob(int id)
        {
            var userId = User.Identity.GetUserId();

            SavedJob appliedJobs = new SavedJob
            {
                JobID=id,
                JobSeekerID=userId
            };
            var result = jobServices.SaveJob(appliedJobs);

            ViewBag.Message = result ? "Job Saved" : "Job already saved previously";

            return RedirectToAction("SavedJobs", "Job"); 
        }

        public ActionResult ApplyToJob(int id)
        {
            var userId = User.Identity.GetUserId();

            
            var result = jobServices.ApplyJob(userId, id);
            if (result)
            {
                return RedirectToAction("SuccessApplication", "Job");
            }
            else {
                return RedirectToAction("FailedApplication", "Job");
            }
           
        }
        public ActionResult SuccessApplication()
        {
            return View();
        }
        public ActionResult FailedApplication()
        {
            return View();
        }

        public ActionResult JobApplicants(int id)
        {
            
            var result = jobServices.GetJobApplicants(id);

            return View(result);
        }

        public ActionResult SavedJobs()
        {
            var userId = User.Identity.GetUserId();
            var result = jobServices.GetSavedJobs(userId);

            return View(result);
        }


    }

    
    


}
