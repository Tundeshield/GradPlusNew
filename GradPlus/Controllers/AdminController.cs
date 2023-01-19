using GradPlus.Data.Models.Domain;
using GradPlus.Models;
using GradPlus.Services.IServices;
using GradPlus.Services.Services;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace GradPlus.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext context;
        

        public AdminController()
        {
            context = new ApplicationDbContext();
        }
       

        // GET: CompanyCategories/Create
        public ActionResult GetUsers()
        {
            return View();
        }

        public ActionResult GetRoles()
        {
            
            return View(context.Roles.ToList());
        }

      
        public ActionResult AddRole()
        {         
            return View();
        }

        [HttpPost]
        public ActionResult AddRole(FormCollection collection)
        {
            try
            {
                IdentityRole role = new IdentityRole(collection["RoleName"]);
                context.Roles.Add(role);
                context.SaveChanges();
                return RedirectToAction("GetRoles");
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
        }

        public ActionResult GetRolesForUser()
        {
            //Username Dropdown
            var userList = context.Users.OrderBy(u => u.UserName).ToList().Select(uu => new SelectListItem { Value = uu.UserName.ToString(), Text = uu.UserName }).ToList();
            ViewBag.Users = userList;// Put in view bag
            return View();
        }

        [HttpPost]
        public ActionResult GetRolesForUser(string userName)
        {
            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var um = new UserManager<ApplicationUser>
           (new UserStore<ApplicationUser>(context));
            ViewBag.userRoles = um.GetRoles(user.Id);
            return View("GetRolesForUserConfirmed");
        }

        //Manage User roles
        public ActionResult ManageUserRoles()
        {
            //Prepare dropdown for users
            var userList = context.Users.OrderBy(u => u.UserName).ToList().Select(uu => new SelectListItem
            {
                Value = uu.UserName.ToString(),
                Text = uu.UserName
            }).ToList();
            ViewBag.Users = userList;

            //Dropdown for roles
            var roleList = context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text=rr.Name }).ToList();
            ViewBag.Roles = roleList;
            return View();
        }

        //Post User role update
        [HttpPost]
        public ActionResult ManageUserRoles(string userName, string roleName)
        {
            ApplicationUser user = context.Users.Where(u => u.UserName.Equals(userName, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            var um = new UserManager<ApplicationUser>
            (new UserStore<ApplicationUser>(context));
            var idResult = um.AddToRole(user.Id, roleName);

            //Put roles list to view bag
            var roleList = context.Roles.OrderBy(r => r.Name).ToList().Select(rr => new SelectListItem { Value = rr.Name.ToString(), Text = rr.Name }).ToList();
            ViewBag.Roles = roleList;

            //Prepare dropdown for users
            var userList = context.Users.OrderBy(u => u.UserName).ToList().Select(uu => new SelectListItem
            {
                Value = uu.UserName.ToString(),
                Text = uu.UserName
            }).ToList();
            ViewBag.Users = userList;

            return View("ManageUserRoles");
        }


    }
}