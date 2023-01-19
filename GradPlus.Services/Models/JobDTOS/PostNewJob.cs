using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradPlus.Services.Models.JobDTOS
{
    public class PostNewJob
    {
            public int ID { get; set; }
            [Display(Name = "Job Title")]
            public string JobTitle { get; set; }
            public string Description { get; set; }
        public string JobCategory { get; set; }
        public int Salary { get; set; }
            public int EmployerID { get; set; }//to get the id of the employer
        
    }
}
