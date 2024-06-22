using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAT.DTO
{
  public  class VechileMstDTO
    {
        public int VechileId { get; set; }
        public Nullable<int> VehcileType { get; set; }
        public String VehcileTypeValue { get; set; }
        public string VechileNumber { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public byte[] Timestamp { get; set; }
        public bool IsDeleted { get; set; }

       
    }

    

}
