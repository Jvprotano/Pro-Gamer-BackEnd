using ProGamer.BackEnd.Services.Interfaces;
using System;
using System.Web.Http;
using System.Threading.Tasks;
using ProGamer.BackEnd.Models.Request;




namespace ProGamer.BackEnd.Controllers
{
    [RoutePrefix("api/register")]
    public class RegisterUserController : BaseController
    {
        private readonly IRegisterUserService _registerUserService = null;
        public RegisterUserController(IRegisterUserService registerUserService)
        {
            _registerUserService = registerUserService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("user")]
        public async Task<IHttpActionResult> User([FromBody] RegisterUserRequest request)
        {
            try
            {
            
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


    }
}