using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSAT.DTO
{
  public  class JobSheetTxnDetDTO
    {
        public int JobTxnSheetDetId { get; set; }
        public int JobSheetTxnId { get; set; }
        public Nullable<System.DateTime> DateTime { get; set; }
        public String Date { get; set; }
        public int VechileId { get; set; }
        public Nullable<int> RunningHours { get; set; }
        public int EmplyoeeId { get; set; }
        public Nullable<decimal> Advance { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<decimal> DriverBeta { get; set; }
        public int DieselFrom { get; set; }
        public Nullable<decimal> DieselLtr { get; set; }
        public Nullable<decimal> DieselRate { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public byte[] Timestamp { get; set; }
        public bool IsDeleted { get; set; }



        //Load
 
        
        public List<EmplyoeeMstDTO> EmplyoeeList { get; set; }
        public List<VechileMstDTO> VechileList { get; set; }
        public List<MJEMSysLovDTO> DieselFromList { get; set; }

    }
}
