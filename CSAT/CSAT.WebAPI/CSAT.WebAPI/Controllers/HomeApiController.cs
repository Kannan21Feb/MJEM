using CSAT.BLL;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace CSAT.WebAPI.Controllers
{
    [RoutePrefix("api/Home")]
    public class HomeApiController : ApiController
    {
        // GET: api/Home
        [HttpGet]
        public string Get()
        {
            return " MJEM Api time: "+ DateTime.Now.ToString();
        }

        [Route("ShortURL")]
        [HttpGet]
        public string GenerateShorterURL()
        {
            
            FeedbackServicesBLL feedbackServiceBLL = null;
            try
            {
                feedbackServiceBLL = new FeedbackServicesBLL();
                var shortURL = feedbackServiceBLL.GenerateShorterURL();
                
                return shortURL;
            }
            catch (Exception ex)
            {
                
                return string.Empty;
            }
            finally
            {
                feedbackServiceBLL = null;
            }
        }
    }
}
