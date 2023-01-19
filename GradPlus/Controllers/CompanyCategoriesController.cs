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
    public class CompanyCategoriesController : Controller
    {
      
        private IJobServices jobServices;
        private IUserServices userServices;


        public CompanyCategoriesController()
        {
            jobServices = new JobServices();
            userServices = new UserServices();
        }

        //[ActionName("Index")]
        // GET: CompanyCategories
        public ActionResult GetCompanyCategories()
        {
            return View(userServices.GetCompanyCategories());
        }


        // GET: CompanyCategories/Details/5
        public ActionResult GetCompanyCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyCategory companyCategory = userServices.GetCompanyCategory(id);
            if (companyCategory == null)
            {
                return HttpNotFound();
            }
            return View(companyCategory);
        }

         // GET: CompanyCategories/Create
        public ActionResult CreateCompanyCategory()
        {
            return View();
        }

        // POST: CompanyCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCompanyCategory([Bind(Include = "ID,Name")] CompanyCategory companyCategory)
        {
            if (ModelState.IsValid)
            {
                userServices.CreateCompanyCategory(companyCategory);
                //db.SaveChanges();
                return RedirectToAction("GetCompanyCategories");
            }

            return View(companyCategory);
        }

        // GET: CompanyCategories/Edit/5
        public ActionResult EditCompanyCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyCategory companyCategory = userServices.GetCompanyCategory(id);
            if (companyCategory == null)
            {
                return HttpNotFound();
            }
            return View(companyCategory);
        }

        // POST: CompanyCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCompanyCategory([Bind(Include = "ID,Name")] CompanyCategory companyCategory)
        {
            if (ModelState.IsValid)
            {
                userServices.EditCompanyCategory(companyCategory.ID, companyCategory);

                return RedirectToAction("GetCompanyCategories");
            }
            return View(companyCategory);
        }

        // GET: CompanyCategories/Delete/5
        public ActionResult DeleteCompanyCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyCategory companyCategory = userServices.GetCompanyCategory(id);
            if (companyCategory == null)
            {
                return HttpNotFound();
            }
            return View(companyCategory);
        }

       
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
