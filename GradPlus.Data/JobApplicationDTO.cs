using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradPlus.Data
{
    public class JobApplicationDTO
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public string Description { get; set; }
        public string JobCategory { get; set; }
        public double Salary { get; set; }
        public string CompanyName { get; set; }
        public string ComapanyEmail { get; set; }
        public string CompanyWebsite { get; set; }
        public string CompanyAddress { get; set; }
        public int JobApplicationId { get; set; }
        public DateTime? AppliedJobDate { get; set; }
        public bool? IsApplied { get; set; }
        public bool? IsSaved { get; set; }
    }
}
