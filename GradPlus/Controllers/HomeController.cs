using GradPlus.Data.Models.Domain;
using GradPlus.Services.IServices;
using GradPlus.Services.Services;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GradPlus.Controllers
{
    public class HomeController : Controller
    {

        private IJobServices JobService;
        private IUserServices UserService;

        public HomeController()
        {
            JobService = new JobServices();
            UserService = new UserServices();
        }

        
        public ActionResult Index()
        {
            dynamic IndexModels = new ExpandoObject();
            var JobCategories = JobService.GetJobCategories();
           // IndexModels.Categories = companyCategories;
            return View(JobCategories);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis lacinia gravida lacus at cursus. Nullam et malesuada justo. Nulla eu finibus tellus. Morbi malesuada blandit diam, nec sagittis velit pulvinar in. Nam egestas posuere luctus. Etiam posuere turpis vitae eros convallis, viverra aliquam risus viverra. Etiam vel posuere velit. Curabitur egestas venenatis eleifend. Nunc ullamcorper vehicula malesuada. Nullam rutrum, est in posuere consectetur, mi augue efficitur ipsum, at mattis est arcu cursus elit. Donec id nunc tellus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Duis congue tempus eros. In faucibus diam ac ipsum tincidunt ullamcorper.Mauris euismod luctus rutrum. Ut convallis lacinia ex, vitae malesuada sapien consectetur ac. Donec pretium commodo orci et aliquam. Cras et maximus tellus. Vestibulum laoreet leo id mi luctus euismod.Ut risus risus, maximus ac tincidunt ullamcorper, varius sodales elit. Ut elementum arcu non rutrum semper. Vestibulum porta vehicula lectus. Curabitur in urna ligula. Maecenas sagittis mauris sed turpis laoreet, pellentesque facilisis ligula fermentum.Donec in lacus nunc. Nunc egestas accumsan felis, ut vulputate quam blandit vitae. Donec sollicitudin neque nec mauris laoreet, vel condimentum nisl iaculis.Proin ultricies lacinia lorem ac convallis. Nunc quis auctor urna.";

            return View();
        }


        public ActionResult Jobs()
        {
            
           IList<Job> jobs= JobService.GetJobs();
            return View(jobs);
        }

        public ActionResult GetEmployers()
        {

            IList<Employer> employers = UserService.GetEmployers();
            return View(employers);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //Get Jobs categories
        public ActionResult GetJobCategories()
        {
            var categories = JobService.GetJobCategories();
            if (categories.Count == 0)
            {
                return View("There are no categories added to database.");
            }
            return View(categories);
        }

        //Get category Jobs
        public ActionResult GetCategoryJobs(int id)
        {
            var jobs = JobService.GetJobCategoryJobs(id);
            return View(jobs);
        }

        public ActionResult GetJobDetails(int id)
        {
            var job = JobService.GetJob(id);
           
            return View(job);
        }

    }
}