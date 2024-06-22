using CSAT.BLL;

using CSAT.WebAPI.ActionFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CSAT.WebAPI.Controllers
{
   // [AuthorizationRequired]
    [RoutePrefix("api/CSAT/Admin")]

    public class AdminApiController : ApiController
    {
        #region Private variable.

        private readonly IAdminBLL _adminBLL;

        #endregion

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize product service instance
        /// </summary>
        public AdminApiController(IAdminBLL adminBLL)
        {
            _adminBLL = adminBLL;
        }

        #endregion

        #region public method

        [Route("Dashboard")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            
            try
            {
                var ds = _adminBLL.LoadDashboard();
                
                return Request.CreateResponse(HttpStatusCode.Created, ds);
            }
            catch (Exception ex)
            {
                
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        #endregion

    }
}
