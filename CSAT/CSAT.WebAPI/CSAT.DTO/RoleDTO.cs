using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAT.DTO
{
    public  class RoleDTO
    {
        public int RoleID { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public string RecordStatus { get; set; }

    }
}
