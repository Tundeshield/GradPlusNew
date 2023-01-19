using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradPlus.Services.Models.JobDTOS
{
    public class JobDetailsDTO
    {
        public int ID { get; set; }
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }       
        [Display(Name = "Description")]
        public string Description { get; set; }
        public int Salary { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Display(Name = "Company Email")]
        public string ComapanyEmail { get; set; }
        [Display(Name = "Company Website")]
        public string CompanyWebsite { get; set; }
    }
}
