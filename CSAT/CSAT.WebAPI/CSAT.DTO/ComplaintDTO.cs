using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAT.DTO
{
    public  class ComplaintDTO
    {
        public int ComplaintID { get; set; }
        public int UserAreaID { get; set; }
        public int ComplaintCategoryID { get; set; }
        public string Comments { get; set; }
        public string ByteData { get; set; }
        public byte[] Attachment { get; set; }

        //public int? CreatedBy { get; set; }

        //public DateTime? CreatedAt { get; set; }

        //public int? ModifiedBy { get; set; }

        //public DateTime? ModifiedAt { get; set; }

        public string RecordStatus { get; set; }

    }
}
