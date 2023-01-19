using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradPlus.Services.Models
{
    public class PostJobDTO
    {
        public int ID { get; set; }
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }
        public string Description { get; set; }
        //public string JobCategory { get; set; }
        public int Salary { get; set; }
        [Display(Name = "Job Title")]
        public string CompanyName { get; set; }
        public string ComapanyEmail { get; set; }
        public string CompanyWebsite { get; set; }
        public string CompanyAddress { get; set; }
        public int Job { get; set; }//to get the id of the job
        public int Employer { get; set; }//to get the id of the employer
    }
}
