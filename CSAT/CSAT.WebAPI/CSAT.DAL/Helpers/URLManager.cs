using System;

namespace CSAT.DAL.Helpers
{
   public class URLManager
    {
        public  string GenerateShorterURL()
        {
            var shortURL = Guid.NewGuid().ToString("N").Substring(0, 6).ToLower();
            return shortURL;
        }
    }
}
