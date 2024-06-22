using CSAT.BLL.Implementations.VechileBLL;
using CSAT.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CSAT.WebAPI.Controllers.VechileWebAppAPI
{
    [RoutePrefix("api/VechileWebAPPAPI")]
    public class VechileWebAPPController : ApiController
    {
        #region Private variable.

        private readonly  VechileBLL _VechileBLL = new  VechileBLL();

        #endregion



        #region public method

        [Route("GetAll")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {

            try
            {
                var ds = _VechileBLL.GetAll();

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
                var ds = _VechileBLL.Load();

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
                var ds = _VechileBLL.Get(id);

                return Request.CreateResponse(HttpStatusCode.Created, ds);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }


        [HttpGet, HttpPost]
        [Route("Save")]
        public HttpResponseMessage Save( VechileMstDTO obj)
        {

            try
            {
                var ds = _VechileBLL.Save(obj);

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
                var ds = _VechileBLL.Delete(id);

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
