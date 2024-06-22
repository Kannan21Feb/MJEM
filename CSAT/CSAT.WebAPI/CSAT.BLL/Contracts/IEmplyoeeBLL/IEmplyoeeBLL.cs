using CSAT.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAT.BLL.Contracts.IEmplyoeeBLL
{
   public interface IEmplyoeeBLL
    {
        string Save(EmplyoeeMstDTO model);
        string Delete(int id);
        EmplyoeeMstDTO Get(int id);
        List<EmplyoeeMstDTO> GetAll();

    }
}
