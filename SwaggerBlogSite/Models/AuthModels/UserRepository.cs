using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SwaggerBlogSite.Models.db;
using SwaggerBlogSite.Models.AuthModels;
using SwaggerBlogSite.Models.AuthModels.ViewModels;
using System.Web.Security;

namespace SwaggerBlogSite.Models.AuthModels
{
    public class UserRepository
    {
        private Context db { get; set; }
        public UserRepository()
        {
            db = new Context();
        }
        public User GetUserByEmail(string email) 
        {
            return db.users.FirstOrDefault(u => u.Email == email);
        }
        public List<User> GetAllUsers()
        {
            return db.users.ToList();
        }
        public User GetNewUser(RegisterViewModel regModel)
        {
            if(regModel != null)
            {
                User user = new User
                {
                    Name = regModel.Name,
                    LastName = regModel.LastName,
                    Email = regModel.Email,
                    Password = regModel.Password
                };
                return user;
            }
            return null;
        }
        public User GetExistUser(LoginViewModel loginModel) 
        {
            User user = null;

            user = db.users.FirstOrDefault(u => u.Email == loginModel.Email && u.Password == loginModel.Password);
            if(user != null)
            {
                return user;
            }
            return null;
        }
        
    }
}