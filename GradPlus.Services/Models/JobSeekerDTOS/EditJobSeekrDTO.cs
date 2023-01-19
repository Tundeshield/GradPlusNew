using GradPlus.Data.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradPlus.Services.Models.JobSeekerDTOS
{
    public class EditJobSeekrDTO
    {
        public EditJobSeekrDTO()
        {

        }
        public EditJobSeekrDTO(JobSeeker model)
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
        public string LastName { get; set; }
        public string ResumeFile { get; set; }
        public string CoverLetterFile { get; set; }

    }
}

