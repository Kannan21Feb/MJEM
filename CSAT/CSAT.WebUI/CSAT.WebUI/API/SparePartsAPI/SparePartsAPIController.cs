using CSAT.DTO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CSAT.WebUI.API.SparePartsAPI
{
    [RoutePrefix("api/SparePartsUiAPI")]
    public class SparePartsAPIController : ApiController
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
                var result = BaseApi.GetAsync("api/SparePartsWebAppAPI/GetAll");
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
                var result = BaseApi.GetAsync("api/SparePartsWebAppAPI/Load");
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
                return BaseApi.GetAsync("api/SparePartsWebAppAPI/Get/" + id);


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [Route("Save")]
        [HttpPost]
        public Task<HttpResponseMessage> Save(SparePartsMstDTO obj)
        {

            try
            {
                return BaseApi.PostAsync("api/SparePartsWebAppAPI/Save", obj);


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
                return BaseApi.GetAsync("api/SparePartsWebAppAPI/Delete/" + id);


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion  
    }
}
