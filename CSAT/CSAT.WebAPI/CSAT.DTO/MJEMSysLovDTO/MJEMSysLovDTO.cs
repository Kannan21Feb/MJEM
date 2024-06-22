using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAT.DTO
{
   public class MJEMSysLovDTO
    {
        public int LovId { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string ScreenName { get; set; }
        public string FieldName { get; set; }
        public string LovKey { get; set; }
        public string FieldCode { get; set; }
        public string FieldValue { get; set; }
        public string Remarks { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public byte[] Timestamp { get; set; }
        public bool IsDeleted { get; set; }

    }
}
