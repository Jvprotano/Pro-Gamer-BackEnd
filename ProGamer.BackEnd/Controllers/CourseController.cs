using ProGamer.BackEnd.Models.Request;
using ProGamer.BackEnd.Services.Interfaces;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProGamer.BackEnd.Controllers
{
    [RoutePrefix("api/course")]
    public class CourseController : BaseController
    {
        #region Properties
        private readonly ICourseService _courseService = null;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        #endregion

        #region Methods

        #region RegisterCourse
        [HttpPost]
        [Route("register-course")]
        public async Task<IHttpActionResult> RegisterCourse([FromBody] RegisterCourseRequest request)
        {
            try
            {
                await _courseService.RegisterCourseAsync(request);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

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