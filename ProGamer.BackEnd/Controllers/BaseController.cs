using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;
using ProGamer.BackEnd.Entities;

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

        protected int UserId
        {
            get
            {
                using (var context = new ProGamerEntities())
                {
                    string userName = User.Identity.GetUserName();
                    var user = context.ListUser.FirstOrDefault(u => u.Email == userName);
                    return user != null ? user.Id : 0;
                }
            }
        }
    }
}