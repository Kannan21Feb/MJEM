using CSAT.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAT.DAL.Contracts.IJobSheetTxnDAL
{
   public interface IJobSheetTxnDAL
    {
        string Save(JobSheetTxnDTO model);
        string Delete(int id);
        JobSheetTxnDTO Get(int id);
        List<JobSheetTxnDTO> GetAll();
        JobSheetTxnDTO Load();
        List<LocationMstDTO> SubLocation(LocationMstDTO location);
        DataSet PrintPdf(int id);
    }
}
