
using CSAT.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAT.DAL.Contracts.IVechileDAL
{
   public interface IVechileDLL
    {
        string Save(VechileMstDTO model);
        string Delete(int id);
        VechileMstDTO Get(int id);
        List<VechileMstDTO> GetAll();
        List<MJEMSysLovDTO> Load();

    }
}
