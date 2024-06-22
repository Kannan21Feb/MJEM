using CSAT.DTO;
using CSAT.WebUI.API;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace CSAT.WebUI.CustomerAPI
{
    [RoutePrefix("api/CustomerUiAPI")]
    public class CustomerAPIController : ApiController

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
                var result= BaseApi.GetAsync("api/CustomerWebAppAPI/GetAll");
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
                return BaseApi.GetAsync("api/CustomerWebAppAPI/Get/" + id);

               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [Route("Save")]
        [HttpPost]
        public Task<HttpResponseMessage> Save(CustomerMstDTO obj)
        {

            try
            {
                return BaseApi.PostAsync("api/CustomerWebAppAPI/Save", obj);

                
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
                return BaseApi.GetAsync("api/CustomerWebAppAPI/Delete/" + id);

                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
    }
}
