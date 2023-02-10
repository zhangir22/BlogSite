using SwaggerBlogSite.Models.BlogModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;

namespace SwaggerBlogSite.Controllers
{
    
    public class BlogController : Controller
    {
        BlogApiController blogApiController = new BlogApiController();

        public ActionResult Index()
        {
            return View(blogApiController.GetAllBlogs());
        }

        [HttpGet]
        public ActionResult CreateBlog()
        {
            return View();
        }
    
        [HttpPost]
        public ActionResult CreateBlog(BlogViewModel model, int userId)
        {
            blogApiController.CreateBlog(model, userId);
            return Redirect("Index");
        }

        [HttpGet]
        public ActionResult EditBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditBlog(BlogViewModel model, int blogId)
        {
            blogApiController.EditBlog(model, blogId);
            return Redirect("Index");
        }

        [HttpGet]
        public ActionResult DeleteBlog()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult DeleteBlog(BlogViewModel model, int blogId)
        {
            blogApiController.DeleteBlog(model, blogId);
            return Redirect("Index");
        }

    }
}