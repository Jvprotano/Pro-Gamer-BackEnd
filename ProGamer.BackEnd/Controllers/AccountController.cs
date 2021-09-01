using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity.Owin;
using ProGamer.BackEnd.Models.Request;
using ProGamer.BackEnd.Services.Interfaces;

namespace ProGamer.BackEnd.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : BaseController
    {
        #region Properties
        private readonly IAccountService _accountService = null;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        #endregion

        #region Methods

        #region Login
        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<IHttpActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                string url = Url.Link("token", null);

                var response = await _accountService.LoginAsync(request, UserManager, url);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #endregion
    }
}
