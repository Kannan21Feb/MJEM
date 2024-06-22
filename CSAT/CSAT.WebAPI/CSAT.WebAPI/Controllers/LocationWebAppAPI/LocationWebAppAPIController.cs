using CSAT.BLL.Implementations.LocationBLL;
using CSAT.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CSAT.WebAPI.Controllers.LocationWebAppAPI
{
    [RoutePrefix("api/LocationWebAppAPI")]
    public class LocationWebAppAPIController : ApiController
    {
        #region Private variable.

        private readonly LocationBLL _LocationBLL = new LocationBLL();

        #endregion



        #region public method

        [Route("GetAll")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {

            try
            {
                var ds = _LocationBLL.GetAll();

                return Request.CreateResponse(HttpStatusCode.Created, ds);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("Load")]
        [HttpGet]
        public HttpResponseMessage Load()
        {

            try
            {
                var ds = _LocationBLL.Load();

                return Request.CreateResponse(HttpStatusCode.Created, ds);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }


        [Route("Get/{Id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {

            try
            {
                var ds = _LocationBLL.Get(id);

                return Request.CreateResponse(HttpStatusCode.Created, ds);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }


        [HttpGet, HttpPost]
        [Route("Save")]
        public HttpResponseMessage Save(LocationMstDTO obj)
        {

            try
            {
                var ds = _LocationBLL.Save(obj);

                return Request.CreateResponse(HttpStatusCode.Created, ds);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("Delete/{Id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {

            try
            {
                var ds = _LocationBLL.Delete(id);

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
