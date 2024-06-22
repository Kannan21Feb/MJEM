using CSAT.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAT.DAL.Contracts.CustomerDAL
{
  public  interface ICustomerDAL
    {
        
        string Save(CustomerMstDTO model);
        string Delete(int id);
        CustomerMstDTO Get(int id);
        List<CustomerMstDTO> GetAll();
    }
}
