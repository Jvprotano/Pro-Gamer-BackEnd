﻿using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace ProGamer.BackEnd.Controllers
{
    [Authorize]
    public class BaseController : ApiController
    {
        protected bool IsAuthenticated
        {
            get
            {
                return User.Identity.IsAuthenticated;
            }
        }

        protected string UserName
        {
            get
            {
                return User.Identity.GetUserName();
            }
        }

        protected string UserId
        {
            get
            {
                using (var context = new Entities.Entities() )
                {
                    string userName = User.Identity.GetUserName();
                    var user = context.ListAspNetUsers.FirstOrDefault(u => u.UserName == userName);
                    return user != null ? user.Id : "";
                }
            }
        }
    }
}