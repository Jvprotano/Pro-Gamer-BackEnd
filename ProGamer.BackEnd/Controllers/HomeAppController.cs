using ProGamer.BackEnd.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ProGamer.BackEnd.Controllers
{
    [RoutePrefix("api/home")]
    public class HomeAppController : BaseController
    {
        #region Properties
        private readonly IHomeAppService _homeAppService = null;

        public HomeAppController(IHomeAppService homeAppService)
        {
            _homeAppService = homeAppService;
        }
        #endregion

        #region Methods

        #region LoadHome
        [HttpGet]
        [AllowAnonymous]
        [Route("load-data")]
        public async Task<IHttpActionResult> LoadDataHome()
        {
            var homeResponse = await _homeAppService.LoadDataHomeAsync();

            return Ok(homeResponse);
        }
        #endregion

        #endregion
    }
}