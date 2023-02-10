using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SwaggerBlogSite.Models.AuthModels;
using SwaggerBlogSite.Models.BlogModels;

namespace SwaggerBlogSite.Models.db
{
    public class Context:DbContext
    {
        public Context():
            base("Context") 
        { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> users { get; set; }
        public DbSet<Blog> blogs { get; set; }
    }
}