using System;

namespace CSAT.DTO
{
    public class TokenDTO
    {
        public int TokenId { get; set; }
        public int CsatUserId { get; set; }
        public string AuthToken { get; set; }
        public  DateTime IssuedOn { get; set; }
        public  DateTime ExpiresOn { get; set; }
    }
}
