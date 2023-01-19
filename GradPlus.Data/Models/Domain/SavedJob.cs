using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradPlus.Data.Models.Domain
{
    public class SavedJob
    {
        public int ID { get; set; }
    
        public int JobID { get; set; }
      
        public string JobSeekerID { get; set; }
    }
}
