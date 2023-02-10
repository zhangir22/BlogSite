using SwaggerBlogSite.Models.AuthModels;
using SwaggerBlogSite.Models.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Security;

namespace SwaggerBlogSite.Controllers
{
    public class AuthController : ApiController
    {
        public string Resgister(User user)
        {
            if (user != null)
            {
                using(Context db= new Context())
                {
                    db.users.Add(user);
                    db.SaveChanges();
                }
                return $"User = {user.Name} is registered";
            }
            return $"User is not exits";
        }
        
        public string Authorize(string email, string password)
        {
            User user = null;
            using(Context db = new Context())
            {
                user = db.users.FirstOrDefault(u => u.Email ==email && u.Password == password);
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.Email, true);
                    return $"User = {user.Email} is authorize";
                }
                return "User not found";
            }
            
        }
    }
}