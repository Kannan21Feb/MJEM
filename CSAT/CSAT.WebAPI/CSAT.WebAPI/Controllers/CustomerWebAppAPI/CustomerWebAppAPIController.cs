using CSAT.BLL.Contracts.Customer;
using CSAT.BLL.Implementations.Customer;
using CSAT.DTO;



using CSAT.WebAPI.ActionFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CSAT.WebAPI.Controllers
{
    
    [RoutePrefix("api/CustomerWebAppAPI")]
    public class CustomerWebAppAPIController : ApiController
    {
        #region Private variable.

        private readonly CustomerBLL _CustomerBLL = new CustomerBLL();

        #endregion

       

        #region public method

        [Route("GetAll")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {

            try
            {
                var ds = _CustomerBLL.GetAll();

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
                var ds = _CustomerBLL.Get(id);

                return Request.CreateResponse(HttpStatusCode.Created, ds);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }


        [HttpGet,HttpPost]
        [Route("Save")]
        public HttpResponseMessage Save(CustomerMstDTO obj)
        {
            
            try
            {
                var ds = _CustomerBLL.Save(obj);
     
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
                var ds = _CustomerBLL.Delete(id);

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
