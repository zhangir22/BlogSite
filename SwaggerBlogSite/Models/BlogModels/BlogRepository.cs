using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SwaggerBlogSite.Models.BlogModels.ViewModels;
using SwaggerBlogSite.Models.db;
namespace SwaggerBlogSite.Models.BlogModels
{
    public class BlogRepository
    {
        Context db { get; set; }
        public BlogRepository()
        {
            db = new Context();
        }
        public Blog GetBlogById(int blogId)
        {
            return db.blogs.FirstOrDefault(u => u.Id == blogId);
        }
        public Blog GetNewBlog(BlogViewModel model, int userId)
        {
            return new Blog { Title = model.Title, Body = model.Body, UserId = userId };
        }
        public Blog GetFirstBlogByUserId(int userId)
        {
            return db.blogs.FirstOrDefault(u => u.UserId == userId);
        }
        public List<Blog> GetBlogsOfUsers(int userId)
        {
            return db.blogs.Where(u => u.UserId == userId).ToList();
        }
        public Blog GetLastCreatedBlogByUserId(int userId)
        {
            return db.blogs.LastOrDefault(u=>u.UserId==userId);
        }


    }
}