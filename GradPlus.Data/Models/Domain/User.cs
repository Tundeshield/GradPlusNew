using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradPlus.Data.Models.Domain
{
    public abstract class User 
    {
        [Key]      
        public int ID { get; set; }
        public string IdentityID { get; set; }
        public string Email { get; set; }
        [Display(Name = "Profile Image")]
        public string Profile_Img { get; set; }
        
    }
}
