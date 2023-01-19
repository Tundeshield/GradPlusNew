using GradPlus.Data.Models.Domain;
using GradPlus.Services.IServices;
using GradPlus.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GradPlus.Controllers
{
    public class Helper
    {
        private IJobServices jobServices;
        private IUserServices userServices;


        public Helper()
        {
            jobServices = new JobServices();
            userServices = new UserServices();
        }

        // GET: Helper
        public List<SelectListItem> GetJobCategoryDropDown()
        {
            List<SelectListItem> categoryList = new List<SelectListItem>();
            IList<JobCategory> categories = jobServices.GetJobCategories();
            foreach (var item in categories)
            {
                categoryList.Add(
                    new SelectListItem()
                    {
                        Text = item.Name,
                        Value = item.ID.ToString(),
                        Selected = (item.Name == (categories[0].Name) ? true : false)
                    });
            }
            return categoryList;
        }
    }
}