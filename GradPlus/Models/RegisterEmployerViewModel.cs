using GradPlus.Data.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GradPlus.Models
{
    public class RegisterEmployerViewModel
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Company Name")]
        [Required, MaxLength(50)]
        public string CompanyName { get; set; }
        [Display(Name = "Description")]
        [Required, MaxLength(50)]
        public string CompanyDescription { get; set; }
        [Required, MaxLength(20)]
        public string Website { get; set; }
        [Display(Name = "Employee Count")]
        [Required]
        public StaffStrength EmployeeCount { get; set; }
        [Display(Name = "Year Founded")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime YearFounded { get; set; }       
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Profile Image")]
        public string Profile_Img { get; set; }

        public HttpPostedFileBase ProfileImageFile { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}