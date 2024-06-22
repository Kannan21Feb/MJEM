﻿using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CSAT.BLL;

using CSAT.WebAPI.Filters;

namespace CSAT.WebAPI.Controllers
{
    [RoutePrefix("api/CSAT/Account")]
    public class AuthenticateApiController : ApiController
    {
        #region Private variable.

        private readonly ITokenBLL _tokenBLL;

        #endregion

        #region Public Constructor

        /// <summary>
        /// Public constructor to initialize product service instance
        /// </summary>
        public AuthenticateApiController()
        {
        }
        public AuthenticateApiController(ITokenBLL tokenBLL)
        {
            _tokenBLL = tokenBLL;
        }

        #endregion
        //[HttpGet]
        //public string Get()
        //{
        //    return "Hello";
        //}
        /// <summary>
        /// Authenticates user and returns token with expiry.
        /// </summary>
        /// <returns></returns>
        [ApiAuthenticationFilter]
        [Route("login")]
        //[Route("authenticate")]
        //[Route("get/token")]
        [HttpGet]
        public HttpResponseMessage Authenticate()
        {
            try
            {
                if (System.Threading.Thread.CurrentPrincipal != null && System.Threading.Thread.CurrentPrincipal.Identity.IsAuthenticated)
                {
                    var basicAuthenticationIdentity = System.Threading.Thread.CurrentPrincipal.Identity as BasicAuthenticationIdentity;
                    if (basicAuthenticationIdentity != null)
                    {
                        var userId = basicAuthenticationIdentity.UserId;
                        return GetAuthToken(userId);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [AllowAnonymous]
        [Route("logout")]
        [HttpPost]
        public HttpResponseMessage Logout([FromBody] string Id)
        {
            
            try
            {
                int UserId = 0;
                if (String.IsNullOrEmpty(Id))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
                else
                {
                    UserId = Convert.ToInt32(Id);
                }

                var bResult = _tokenBLL.DeleteByUserId(UserId);
               
                var response = Request.CreateResponse(HttpStatusCode.OK, bResult);
                return response;
            }
            catch (Exception ex)
            {
               
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        /// <summary>
        /// Returns auth token for the validated user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        private HttpResponseMessage GetAuthToken(int userId)
        {
            var token = _tokenBLL.GenerateToken(userId);
            var response = Request.CreateResponse(HttpStatusCode.OK, "Authorized");
            response.Headers.Add("UserId", Convert.ToString(userId));
            response.Headers.Add("Token", token.AuthToken);
            response.Headers.Add("TokenExpiry", ConfigurationManager.AppSettings["AuthTokenExpiry"]);
            response.Headers.Add("Access-Control-Expose-Headers", "Token,TokenExpiry,UserId");
            return response;
        }
    }
}