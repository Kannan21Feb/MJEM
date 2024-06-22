using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CSAT.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                 name: "ShortURL",
                 url: "{shortkey}",
                 defaults: new { controller = "FeedbackServices", action = "Details", id = UrlParameter.Optional }//,
                 //constraints: new { id = @"\d+" }
             );
           
            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "FeedbackServices", action = "Survey", id = UrlParameter.Optional }
            //);

            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );

        }
    }
}

//Plot No:108,4th West Street, Metha Nagar,
//Kundrathur, Chennai.
