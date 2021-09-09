using Microsoft.AspNet.Identity.Owin;
using ProGamer.BackEnd.Models.Response;
using ProGamer.BackEnd.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ProGamer.BackEnd.Controllers
{
    [RoutePrefix("api/course")]
    public class CourseController : BaseController
    {
        #region Properties
        private readonly ICourseService _courseService = null;
        private ApplicationUserManager _userManager;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
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

        #endregion

        #region Methods

        #region InfoCourse
        [HttpGet]
        [AllowAnonymous]
        [Route("info")]
        public async Task<IHttpActionResult> InfoCourse(int id)
        
        {
            try
            {
                var CourseInfoResult = await _courseService.CourseInfoAsync(id);
                return Ok(CourseInfoResult);
            }
            catch (Exception ex)
            {
                return BadRequest("Curso não encontrado");
            }
            
        }
        #endregion

        #endregion

    }
}