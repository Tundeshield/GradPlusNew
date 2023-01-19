using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradPlus.Data.Models.Domain
{
   public class Employer : User
    {
        [Required, MaxLength(50)]
        public string CompanyName { get; set; }
        [Required,MaxLength(80)]
        public string CompanyDescription { get; set; }
        [Required, MaxLength(20)]
        public string Website { get; set; }
        [Display(Name = "Employee Count")]
        public StaffStrength EmployeeCount { get; set; }
        public DateTime YearFounded { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
    }
}
