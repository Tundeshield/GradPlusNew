using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradPlus.Data.Models.Domain
{
    public enum StaffStrength
    {
        [Display(Name = "1 - 10")]
        less_than_10,
        [Display(Name = "10 - 20")]
        between_10_and_20,
        [Display(Name = "21 - 50")]
        between_20_and_50,
        [Display(Name = "51 - 100")]
        between_50_and_100,
        [Display(Name = "> 100")]
        more_than_100
    }
}
