using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradPlus.Data.Models.Domain
{
    public class JobSeeker:User
    {
        [Display(Name = "First Name")]
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [Display(Name = "Resume")]
        [Required]
        public string ResumeFile { get; set; }
        [Display(Name = "Cover Letter")]
        [Required]
        public string CoverLetterFile { get; set; }
        public Profession Profession { get; set; }
        public virtual ICollection<JobApplication> JobApplications { get; set; }
        public virtual ICollection<SavedJob> SavedJobs { get; set; }
    }
}
