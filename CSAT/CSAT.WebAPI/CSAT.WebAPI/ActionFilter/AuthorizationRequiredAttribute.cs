
using CSAT.BLL;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace CSAT.WebAPI.ActionFilter
{
    public class AuthorizationRequiredAttribute: System.Web.Http.Filters.ActionFilterAttribute
    {
        //private const string Token = "Token";
        //public override void OnActionExecuting(HttpActionContext filterContext)
        //{
        //    //  Get API key provider
        //    var provider = filterContext.ControllerContext.Configuration
        //        .DependencyResolver.GetService(typeof(ITokenBLL)) as ITokenBLL;

        //    if (filterContext.Request.Headers.Contains(Token))
        //    {
        //        var tokenValue = filterContext.Request.Headers.GetValues(Token).First();

        //        // Validate Token
        //        if (provider != null && !provider.ValidateToken(tokenValue))
        //        {
        //            var responseMessage = new HttpResponseMessage(HttpStatusCode.Unauthorized) { ReasonPhrase = "Invalid Request" };
        //            filterContext.Response = responseMessage;
        //        }
        //    }
        //    else
        //    {
        //        filterContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
        //    }

        //    base.OnActionExecuting(filterContext);

        //}

        //public static async Task<MvcHtmlString> Autentication ()
        
    }
}