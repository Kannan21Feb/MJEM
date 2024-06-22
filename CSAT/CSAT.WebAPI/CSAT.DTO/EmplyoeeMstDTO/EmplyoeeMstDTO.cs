using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAT.DTO
{
   public class EmplyoeeMstDTO
    {
        public int EmplyoeeId { get; set; }
        public string EmplyoeeName { get; set; }
        public string MobileNumber { get; set; }
        public string GovtId { get; set; }
        public string Address { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public byte[] Timestamp { get; set; }
        public bool IsDeleted { get; set; }
    }
}
