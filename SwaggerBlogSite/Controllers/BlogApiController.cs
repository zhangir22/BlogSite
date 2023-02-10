using SwaggerBlogSite.Models.AuthModels;
using SwaggerBlogSite.Models.BlogModels;
using SwaggerBlogSite.Models.BlogModels.ViewModels;
using SwaggerBlogSite.Models.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebGrease.Css.Extensions;

namespace SwaggerBlogSite.Controllers
{
    public class BlogApiController : ApiController
    {
        private BlogRepository blogRepos = new BlogRepository();
        private UserRepository userRepos = new UserRepository();

        public List<Blog> GetAllBlogs()
        {
            return blogRepos.GetBlogsOfUsers(userRepos.GetUserByEmail(User.Identity.Name.ToString()).Id);
        }
        public string CreateBlog(BlogViewModel model, int userId)
        {
            if (model != null)
            {
                using(Context db = new Context())
                {
                    db.blogs.Add(blogRepos.GetNewBlog(model, userId));
                    db.SaveChanges();
                    return "Blog is created";
                }
            }
            return "Model is not exist";
        }
        public string EditBlog(BlogViewModel model,int blogId)
        {
            if(model != null)
            {
               
                    using (Context db = new Context()) 
                    {
                    Blog blog = db.blogs.FirstOrDefault(u => u.Id == blogId);
                        blog.Title = model.Title;
                        blog.Body = model.Body;
                        db.SaveChanges();
                    }
                    return "Blog was edited";
            }
            return "Model is not working";
        }
        public string DeleteBlog(BlogViewModel model,int blogId)
        {
            if(model != null)
            {
                using (Context db = new Context()) 
                {
                    var blog = db.blogs.FirstOrDefault(u=>u.Id==blogId);
                    db.blogs.Remove(blog);
                    db.SaveChanges();
                }
                return "Blog was deleted";
            }
            return "model is not working";
        }

    }
}