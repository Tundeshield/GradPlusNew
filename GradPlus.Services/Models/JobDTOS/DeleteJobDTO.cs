using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradPlus.Services.Models.JobDTOS
{
    public class DeleteJobDTO
    {
        public int ID { get; set; }
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }
    }
}
