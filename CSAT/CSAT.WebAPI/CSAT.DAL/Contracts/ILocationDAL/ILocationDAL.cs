using CSAT.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAT.DAL.Contracts.ILocationDAL
{
   public interface ILocationDAL
    {
        string Save(LocationMstDTO model);
        string Delete(int id);
        LocationMstDTO Get(int id);
        List<LocationMstDTO> GetAll();
        List<LocationMstDTO> Load();
    }
}
