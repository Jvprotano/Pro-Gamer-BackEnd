using Microsoft.AspNet.Identity.Owin;
using ProGamer.BackEnd.Services.Interfaces;
using System;
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
        [Route("")]
        public async Task<IHttpActionResult> Get(int id)
        
        {
            try
            {
                var courseInfoResult = await _courseService.GetAsync(id);
                if (courseInfoResult == null)
                {
                    return NotFound();
                }
                return Ok(courseInfoResult);
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