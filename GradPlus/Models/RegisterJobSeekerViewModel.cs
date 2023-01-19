using GradPlus.Data.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GradPlus.Models
{
    public class RegisterJobSeekerViewModel
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "First Name")]
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public Profession Profession { get; set; }
        [Display(Name = "Profile Image")]
        public string ProfileImagePath { get; set; }
        public HttpPostedFileBase ProfileImageFile { get; set; }
        [Display(Name = "Resume")]
        public string ResumePath { get; set; }
        public HttpPostedFileBase ResumeFile { get; set; }
        [Display(Name = "Cover Letter")]
        public string CoverLetterPath { get; set; }     
        public HttpPostedFileBase CoverLetterFile { get; set; }     
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