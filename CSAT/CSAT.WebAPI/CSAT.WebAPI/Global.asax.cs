
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using AutoMapper;
using System.Web.Routing;
using System.Web.Http.Dispatcher;

namespace CSAT.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //GlobalConfiguration.Configure(config =>
            //{
            //    config.Services.Replace(typeof(IHttpControllerTypeResolver), new DefaultHttpControllerTypeResolver());
   
            //});
          

            //Define Formatters
            //var formatters = GlobalConfiguration.Configuration.Formatters;
            //var jsonFormatter = formatters.JsonFormatter;
            //var settings = jsonFormatter.SerializerSettings;
            //settings.Formatting = Formatting.Indented;
             


            //AutoMapper Config
            Mapper.Initialize(x =>
            {
                x.AddProfile(new CSAT.DAL.AutoMapperIntialisation.AutoMapperConfiguration().MappingProfile);
            });
        }
    }
}
