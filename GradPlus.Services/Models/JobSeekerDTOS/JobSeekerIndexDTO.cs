﻿using GradPlus.Data.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradPlus.Services.Models.JobSeekerDTOS
{
    public class JobSeekerIndexDTO
    {
       

        public int ID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
       

    }
}

