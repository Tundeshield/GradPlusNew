using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GradPlus.Models
{
    public class MediaUploadModel
    {
        public string Filename { get; set; }
        public IFormFile File { get; set; }
    }
}