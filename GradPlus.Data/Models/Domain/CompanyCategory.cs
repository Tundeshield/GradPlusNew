using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradPlus.Data.Models.Domain
{
    public class CompanyCategory
    {
        public int ID { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public virtual ICollection<Employer> Employers { get; set; }
    }
}
