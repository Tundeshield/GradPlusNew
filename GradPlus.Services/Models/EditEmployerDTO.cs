using GradPlus.Data.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradPlus.Services.DTO
{
    public class EditEmployerDTO
    {
        [Key]
        public int ID { get; set; }
        public string Email { get; set; }
        public string Profile_Img { get; set; }
        public string CompanyName { get; set; }
        public string CompanyDescription { get; set; }
        public string Website { get; set; }
        public StaffStrength EmployeeCount { get; set; }
        public DateTime YearFounded { get; set; }
    }
}
