using CSAT.BLL.Implementations.JobSheetTxnBLL;
using CSAT.DTO;
using CSAT.WebAPI.ActionFilter;
using CSAT.WebAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CSAT.WebAPI.Controllers.JobSheetTxnWebAppAPI
{
    
    [RoutePrefix("api/JobSheetTxnWebAppAPI")]
    public class JobSheetTxnWebAppAPIController : ApiController
    {
        #region Private variable.

        private readonly JobSheetTxnBLL _JobSheetTxnBLL = new JobSheetTxnBLL();

        #endregion



        #region public method

        [Route("GetAll")]
        [HttpGet]
        public HttpResponseMessage GetAll()
        {

            try
            {
                var ds = _JobSheetTxnBLL.GetAll();

                return Request.CreateResponse(HttpStatusCode.Created, ds);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
            
        }





        [Route("Load")]
        [HttpGet]
        public HttpResponseMessage Load()
        {

            try
            {
                var ds = _JobSheetTxnBLL.Load();

                return Request.CreateResponse(HttpStatusCode.Created, ds);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }


        [Route("Get/{Id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {

            try
            {
                var ds = _JobSheetTxnBLL.Get(id);

                return Request.CreateResponse(HttpStatusCode.Created, ds);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }


        [HttpGet, HttpPost]
        [Route("Save")]
        public HttpResponseMessage Save(JobSheetTxnDTO obj)
        {

            try
            {
                var ds = _JobSheetTxnBLL.Save(obj);

                return Request.CreateResponse(HttpStatusCode.Created, ds);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Route("Delete/{Id}")]
        [HttpGet]
        public HttpResponseMessage Delete(int id)
        {

            try
            {
                var ds = _JobSheetTxnBLL.Delete(id);

                return Request.CreateResponse(HttpStatusCode.Created, ds);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Route("SubLocation")]
        [HttpPost]
        public HttpResponseMessage SubLocation(LocationMstDTO location)
        {

            try
            {
                var ds = _JobSheetTxnBLL.SubLocation(location);

                return Request.CreateResponse(HttpStatusCode.Created, ds);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }


        [Route("Export/{id}/{exportType}")]
        [HttpPost,HttpGet]
        public HttpResponseMessage PrintPdf(int id, string exportType)
        {

            try
            {
                var ds = _JobSheetTxnBLL.PrintPdf( id);
                if (exportType== "Pdf")
                {
                    return ds.Tables[0].Rows.Count > 0 ? ExportHelper.PdfExportForList(ds) : Request.CreateResponse(HttpStatusCode.InternalServerError, "Print Failed");
                }
                else
                {
                    return ds.Tables[0].Rows.Count > 0 ? Request.CreateResponse(HttpStatusCode.Created, ExportHelper.CreateExcelTable(ds)) : Request.CreateResponse(HttpStatusCode.InternalServerError, "Print Failed");
                }
                

            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }

        }


        #endregion
    }
}
