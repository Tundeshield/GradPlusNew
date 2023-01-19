using GradPlus.Data.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradPlus.Services.Models
{
    public class JobSeekerDTO
    {
        public JobSeekerDTO(JobSeeker model)
        {
            ID = model.ID;
            Email = model.Email;
            FirstName = model.FirstName;
            LastName = model.LastName;
            ResumeFile = model.ResumeFile;
            CoverLetterFile = model.CoverLetterFile;        
        }
        public int ID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        public string ResumeFile { get; set; }
        public string CoverLetterFile { get; set; }
        

    }
}
