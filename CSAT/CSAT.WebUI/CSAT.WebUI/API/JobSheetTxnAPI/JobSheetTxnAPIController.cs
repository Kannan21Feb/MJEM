using CSAT.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CSAT.WebUI.API.JobSheetTxnAPI
{
    [RoutePrefix("api/JobSheetTxnUiAPI")]
    public class JobSheetTxnAPIController : ApiController
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
                var result = BaseApi.GetAsync("api/JobSheetTxnWebAppAPI/GetAll");
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
                var result = BaseApi.GetAsync("api/JobSheetTxnWebAppAPI/Load");
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
                return BaseApi.GetAsync("api/JobSheetTxnWebAppAPI/Get/" + id);


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [Route("Save")]
        [HttpPost]
        public Task<HttpResponseMessage> Save(JobSheetTxnDTO obj)
        {

            try
            {
                return BaseApi.PostAsync("api/JobSheetTxnWebAppAPI/Save", obj);


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
                return BaseApi.GetAsync("api/JobSheetTxnWebAppAPI/Delete/" + id);


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [Route("SubLocation")]
        [HttpPost]
        public Task<HttpResponseMessage> SubLocation(LocationMstDTO SubLocation)
        {

            try
            {
                return BaseApi.PostAsync("api/JobSheetTxnWebAppAPI/SubLocation",SubLocation);


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [Route("Export/{id}/{exportType}")]
        [HttpPost,HttpGet]
        public Task<HttpResponseMessage> PrintPdf(int id,string exportType)
        {

            try
            {
                
                return BaseApi.GetAsync("api/JobSheetTxnWebAppAPI/Export/" + id +"/"+ exportType);


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


       



        #endregion
    }
}
