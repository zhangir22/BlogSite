using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SwaggerBlogSite.Models.BlogModels
{
    [Table("Blog")]
    public class Blog
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("body")]
        public string Body { get; set; }
        [Column("userId")]
        public int UserId { get; set; }

    }
}