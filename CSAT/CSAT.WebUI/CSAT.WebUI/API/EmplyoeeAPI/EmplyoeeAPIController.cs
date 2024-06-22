using CSAT.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CSAT.WebUI.API.EmplyoeeAPI
{
    [RoutePrefix("api/EmplyoeeUiAPI")]
    public class EmplyoeeAPIController : ApiController
    {
        #region Private Variables
        private readonly WebUIAPIHelperController BaseApi = new WebUIAPIHelperController();

        #endregion

        #region public method

        [Route("GetAll")]
        [HttpGet]
        public Task<HttpResponseMessage> GetAll()
        {

            try
            {
                var result = BaseApi.GetAsync("api/EmplyoeeWebAppAPI/GetAll");
                return result;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [Route("Load")]
        [HttpGet]
        public Task<HttpResponseMessage> Load()
        {

            try
            {
                var result = BaseApi.GetAsync("api/EmplyoeeWebAppAPI/Load");
                return result;


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [Route("Get/{Id}")]
        [HttpGet]
        public Task<HttpResponseMessage> Get(int id)
        {

            try
            {
                return BaseApi.GetAsync("api/EmplyoeeWebAppAPI/Get/" + id);


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [Route("Save")]
        [HttpPost]
        public Task<HttpResponseMessage> Save(EmplyoeeMstDTO obj)
        {

            try
            {
                return BaseApi.PostAsync("api/EmplyoeeWebAppAPI/Save", obj);


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        [Route("Delete/{Id}")]
        [HttpGet]
        public Task<HttpResponseMessage> Delete(int id)
        {

            try
            {
                return BaseApi.GetAsync("api/EmplyoeeWebAppAPI/Delete/" + id);


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
    }
}
