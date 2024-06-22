using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace CSAT.Resolver.UserDetailsHelper
{
   public class CurrentUserHelper
    {
        public UserDetails CurrentUserDetailsUsingHeaders ()
        {
            try
            {
                UserDetails user = new UserDetails();

                var context = HttpContext.Current;
                var reqHeaders = context.Request.Headers;
                var UserInfo = reqHeaders.GetValues("UserId");
                if (UserInfo!=null)
                {
                    var jss = new JavaScriptSerializer();
                    user = jss.Deserialize<UserDetails>(UserInfo.FirstOrDefault());

                }
                if (user==null)
                {
                    context.Response.Redirect("",true);
                    return null;
                }
                else { return user; }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }


    public  class UserDetails
    {
        public int UserId { get; set; }
    }
}
