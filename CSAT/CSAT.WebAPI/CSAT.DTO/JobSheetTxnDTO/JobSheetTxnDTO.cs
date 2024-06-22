using CSAT.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSAT.DTO
{
  public  class JobSheetTxnDTO
    {
        public int JobSheetTxnId { get; set; }
        public int CustomerId { get; set; }
        public int LocationId { get; set; }
        public Nullable<int> ParentLocationId { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public byte[] Timestamp { get; set; }
        public bool IsDeleted { get; set; }

        //TxnDet
       public List<JobSheetTxnDetDTO> JobSheetTxnDet { get; set; }

        //GetAll
        public string Customer { get; set; }
        public string ParentLocation { get; set; }
        public string Location { get; set; }

        //Load
        public List<CustomerMstDTO> Customers { get; set; }
        public List<LocationMstDTO> Locations { get; set; }

        public List<LocationMstDTO> ParentLocations { get; set; }
        public List<EmplyoeeMstDTO> Employees { get; set; }
        public List<VechileMstDTO> Vechiles { get; set; }
        public List<MJEMSysLovDTO> DiselFrom { get; set; }

    }


   


    //public class JobSheetTxnDetDTO
    //{
    //    public int JobTxnSheetDetId { get; set; }
    //    public int JobSheetTxnId { get; set; }
    //    public Nullable<System.DateTime> DateTime { get; set; }
    //    public int VechileId { get; set; }
    //    public Nullable<int> RunningHours { get; set; }
    //    public int EmplyoeeId { get; set; }
    //    public Nullable<decimal> Advance { get; set; }
    //    public Nullable<decimal> Rate { get; set; }
    //    public Nullable<decimal> DriverBeta { get; set; }
    //    public int DieselFrom { get; set; }
    //    public int CreatedBy { get; set; }
    //    public System.DateTime CreatedDate { get; set; }
    //    public Nullable<int> ModifiedBy { get; set; }
    //    public Nullable<System.DateTime> ModifiedDate { get; set; }
    //    public byte[] Timestamp { get; set; }
    //    public bool IsDeleted { get; set; }
    //}

    
}
