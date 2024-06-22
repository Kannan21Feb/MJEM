using CSAT.BLL.Implementations.EmplyoeeBLL;
using CSAT.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CSAT.WebAPI.Controllers.EmplyoeeWebAppAPI
{
    [RoutePrefix("api/EmplyoeeWebAppAPI")]
    public class EmplyoeeWebAppAPIController : ApiController
    {
        #region Private variable.

        private readonly EmplyoeeBLL _EmplyoeeBLL = new EmplyoeeBLL();

        #endregion



        #region public method

        [Route("GetAll")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {

            try
            {
                var ds = _EmplyoeeBLL.GetAll();

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
                var ds = _EmplyoeeBLL.Get(id);

                return Request.CreateResponse(HttpStatusCode.Created, ds);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }


        [HttpGet, HttpPost]
        [Route("Save")]
        public HttpResponseMessage Save(EmplyoeeMstDTO obj)
        {

            try
            {
                var ds = _EmplyoeeBLL.Save(obj);

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
                var ds = _EmplyoeeBLL.Delete(id);

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

