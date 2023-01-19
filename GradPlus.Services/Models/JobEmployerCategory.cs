using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradPlus.Services.Models
{
    public class JobEmployerCategory
    {
        public int ID { get; set; }
        [Display(Name = "Job Title")]
        [Required, MaxLength(50)]
        public string JobTitle { get; set; }
        public string Location { get; set; }
        [Display(Name = "Job Description")]
        [Required, MaxLength(150)]
        public string Description { get; set; }
        public int Salary { get; set; }
        [Display(Name = "Company Name")]
        [Required, MaxLength(50)]
        public string CompanyName { get; set; }
        [Display(Name = "Contact Email")]
        [Required, MaxLength(50)]
        public string ComapanyEmail { get; set; }
        [Display(Name = "Website")]
        [MaxLength(50)]
        public string CompanyWebsite { get; set; }
        [Display(Name = "Job Address")]
        [Required, MaxLength(70)]
        public string CompanyAddress { get; set; }
        public int JobCategoryID { get; set; }
        public int EmployerID { get; set; }
    }
}
