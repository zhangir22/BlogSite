using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace SwaggerBlogSite.Models.BlogModels.ViewModels
{
    public class BlogViewModel
    {
        [Display(Name = "Title")]
        [Required]
        public string Title { get; set; }
        [Display(Name = "Body")]
        [Required]
        public string Body { get; set; }

    }
}