using GradPlus.Data.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradPlus.Services.Models.JobSeekerDTOS
{
    public class JobApplicantDto
    {
        public string JobSeekerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Picture { get; set; }
        public string Resume { get; set; }
        public string CoverLetter { get; set; }
        public string Email { get; set; }
       
    }

    public class JobApplicantsDto
    {
        public Job Job { get; set; }
        public int JobId { get; set; }
        public List<JobApplicantDto> JobApplicants { get; set; }
    }

}
