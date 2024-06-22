using System;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CSAT.BLL;
using CSAT.DTO;

using CSAT.WebAPI.Helpers;

namespace CSAT.WebAPI.Controllers
{
    [RoutePrefix("api/CSAT")]
    public class FeedbackServicesApiController : ApiController
    {
        // POST: api/FeedbackServices
        [Route("CSSurvey")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody] SurveyDTO ObjSurvey)
        {
           
            FeedbackServicesBLL feedbackServiceBLL = null;
            try
            {
                if (!ModelState.IsValid || ObjSurvey == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                feedbackServiceBLL = new FeedbackServicesBLL();
                feedbackServiceBLL.Save(ObjSurvey);
                

                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
               
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            finally
            {
                feedbackServiceBLL = null;
            }
        }


        // POST: api/FeedbackServices
        [Route("CSSurvey/Load/{id}/{ShortKey}")]
        [HttpGet]
        public HttpResponseMessage Get(string Id,string ShortKey) 
        {
           
            FeedbackServicesBLL feedbackServiceBLL = null;
            try
            {
                feedbackServiceBLL = new FeedbackServicesBLL();
                DataSet ds = feedbackServiceBLL.Load(Convert.ToInt32(Id), ShortKey);
                
                return Request.CreateResponse(HttpStatusCode.Created, ds);
            }
            catch (Exception ex)
            {
                
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            finally
            {
                feedbackServiceBLL = null;
            }
        }

        [Route("Complaint")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]ComplaintDTO ObjComplaint)
        {

            
            FeedbackServicesBLL feedbackServiceBLL = null;
            try
            {
                if (!ModelState.IsValid || ObjComplaint == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                feedbackServiceBLL = new FeedbackServicesBLL();
                feedbackServiceBLL.Save(ObjComplaint);

                

                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
               
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Route("PrintQRCode")]
        [HttpGet]
        public HttpResponseMessage GenerateQRCode()
        {
            
            FeedbackServicesBLL feedbackServiceBLL = null;
            try
            {
                feedbackServiceBLL = new FeedbackServicesBLL();
                var objBytes = feedbackServiceBLL.GenerateQRCode();
                string strBaseImgSrc = feedbackServiceBLL.GetImageSrc();
              
                return ExportHelper.PdfExport(objBytes, strBaseImgSrc);
            }
            catch (Exception ex)
            {
                
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            finally
            {
                feedbackServiceBLL = null;
            }
        }

        [Route("GetImage")]
        [HttpGet]
        public HttpResponseMessage GetImage()
        {
            
            FeedbackServicesBLL feedbackServiceBLL = null;
            try
            {
                feedbackServiceBLL = new FeedbackServicesBLL();
                string getImgSrc = feedbackServiceBLL.GetImageSrc();
               
                return Request.CreateResponse(HttpStatusCode.Created, getImgSrc);
            }
            catch (Exception ex)
            {
                
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            finally
            {
                feedbackServiceBLL = null;
            }
        }
    }

}
