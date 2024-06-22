using CSAT.BLL.Contracts.Customer;
using CSAT.DAL.Contracts.CustomerDAL;
using CSAT.DAL.Implementations.CustomerDAL;
using CSAT.DTO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAT.BLL.Implementations.Customer
{
    public  class CustomerBLL:ICustomerBLL
    {
        private readonly CustomerDAL _CustomerDAL = new CustomerDAL();

        /// <summary>

        /// <returns></returns>
      
        public CustomerMstDTO Get(int id)
        {
            
            try
            {
                return _CustomerDAL.Get(id);
                

                
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public string Save(CustomerMstDTO obj)
        {
            
            try
            {
                return _CustomerDAL.Save(obj); 



                
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
        }
        public string Delete(int id)
        {
            
            try
            {
                return _CustomerDAL.Delete(id);
                

              
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
        }
        public List<CustomerMstDTO> GetAll()
        {
           
            try
            {
                return _CustomerDAL.GetAll();
               

               
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
        }
    }
}
