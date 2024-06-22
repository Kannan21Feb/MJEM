using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Http;

namespace CSAT.WebUI.API
{
    
    public class WebUIAPIHelperController : ApiController
    {

        public string api = WebConfigurationManager.AppSettings[@"InternalBaseUrl"].ToString();
        
       
       public  async Task<HttpResponseMessage> GetAsync(string apiurl)
        {
            Task<HttpResponseMessage> response = null;
            var BaseUri = api;
            var GetData = (string.Format(apiurl));
            var result = api + GetData;

            var ts = new TimeSpan(0, 2, 30);
            var jsonContentType = new MediaTypeWithQualityHeaderValue(@"application/json");
            using (HttpClient client = new HttpClient { BaseAddress = new Uri(BaseUri), Timeout = ts })
            {
                client.DefaultRequestHeaders.Accept.Add(jsonContentType);
                response = client.GetAsync(result);

                var res = response.Result;
                return res;


            }

        }




     
        public async Task<HttpResponseMessage> PostAsync(string apiurl,dynamic _dto)
        {
            Task<HttpResponseMessage> response = null;
            var BaseUri = api;
            var GetData = apiurl;
            var result = api + GetData;
            var jsonContentType = new MediaTypeWithQualityHeaderValue(@"application/json");
            var ts = new TimeSpan(0, 2, 30);
            using (HttpClient client = new HttpClient { BaseAddress = new Uri(BaseUri), Timeout = ts })
            {
                var data = JsonConvert.SerializeObject(_dto);
                using (var stringContent = new StringContent(data, Encoding.UTF8, @"application/json"))
                {
                    client.DefaultRequestHeaders.Accept.Add(jsonContentType);

                    response = client.PostAsync(result, stringContent);
                    var res = response.Result;
                    return res;
                }

            }

        }


        public async Task<HttpResponseMessage> PutAsync(string apiurl, dynamic _dto)
        {
            Task<HttpResponseMessage> response = null;
            var BaseUri = api;
            var GetData = apiurl;
            var result = api + GetData;
            var ts = new TimeSpan(0, 2, 30);
            var jsonContentType = new MediaTypeWithQualityHeaderValue(@"application/json");
            using (HttpClient client = new HttpClient { BaseAddress = new Uri(BaseUri), Timeout = ts })
            {
                var data = JsonConvert.SerializeObject(_dto);
                using (var stringContent = new StringContent(data, Encoding.UTF8, @"application/json"))
                {
                    client.DefaultRequestHeaders.Accept.Add(jsonContentType);
                    response = client.PutAsync(result, stringContent);
                    var res = response.Result;
                    
                    return res;
                }

            }

        }
    }
}
