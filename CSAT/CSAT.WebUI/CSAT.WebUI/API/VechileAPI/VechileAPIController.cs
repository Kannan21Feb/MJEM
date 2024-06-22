using CSAT.DTO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CSAT.WebUI.API.VechileAPI
{
    [RoutePrefix("api/VechileUiAPI")]
    public class VechileAPIController : ApiController
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
                var result = BaseApi.GetAsync("api/VechileWebAppAPI/GetAll");
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
                var result = BaseApi.GetAsync("api/VechileWebAppAPI/Load");
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
                return BaseApi.GetAsync("api/VechileWebAppAPI/Get/" + id);


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [Route("Save")]
        [HttpPost]
        public Task<HttpResponseMessage> Save( VechileMstDTO obj)
        {

            try
            {
                return BaseApi.PostAsync("api/VechileWebAppAPI/Save", obj);


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
                return BaseApi.GetAsync("api/VechileWebAppAPI/Delete/" + id);


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
    }
}
