using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ProGamer.BackEnd.Models.Request;
using ProGamer.BackEnd.Services.Interfaces;

namespace ProGamer.BackEnd.Controllers
{
    [RoutePrefix("api/account")]
    public class AccountController : BaseController
    {
        #region Properties
        private readonly IAccountService _accountService = null;
        private ApplicationUserManager _userManager;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public AccountController(ApplicationUserManager userManager,
           ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
        {
            UserManager = userManager;
            AccessTokenFormat = accessTokenFormat;
        }

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

        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }
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

        #region RegisterUser
        [HttpPost]
        [AllowAnonymous]
        [Route("register-user")]
        public async Task<IHttpActionResult> RegisterUser([FromBody] RegisterUserRequest request)
        {
            try
            {
                await _accountService.RegisterUserAsync(request, UserManager);

                return Ok();
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
