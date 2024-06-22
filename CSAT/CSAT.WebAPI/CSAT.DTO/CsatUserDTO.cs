using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAT.DTO
{
    public  class CsatUserDTO
    {
        public int CsatUserID { get; set; }

        public int CustomerID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int RoleID { get; set; }

        public string LoginName { get; set; }

        public string Password { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public string RecordStatus { get; set; }

    }
}
