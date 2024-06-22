using CSAT.DAL.Contracts.CustomerDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSAT.DTO;
using AutoMapper;
using CSAT.DAL.EntityModel;
using System.Web;

using System.Data;


namespace CSAT.DAL.Implementations.CustomerDAL
{
    public class CustomerDAL : ICustomerDAL
    {
       
        

        public CustomerMstDTO Get(int id)
        {
            try
            {
                CustomerMstDTO customerObj = new CustomerMstDTO();
                using (var context = new MJEMEntities())
                {
                    var customer = context.CustomersMsts.Where(x => (bool)!x.IsDeleted && x.CustomerId==id).FirstOrDefault();
                    return customerObj = AutoMapper.Mapper.Map<CustomersMst, CustomerMstDTO>(customer);

                }
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
                var customerList = new List<CustomerMstDTO>();
                using (var context=new MJEMEntities())
                {
                   var customers= context.CustomersMsts.Where(x => (bool)!x.IsDeleted).ToList();
                    return customerList =AutoMapper.Mapper.Map<List<CustomersMst>,List<CustomerMstDTO>> (customers);
                    
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


      

        public string Save(CustomerMstDTO model)
        {
            try
            {
                var EFobjSave = new CustomersMst();
                var Result = "";
                using (var context = new MJEMEntities())
                {
                    if (model.CustomerId > 0)
                    {
                        model.ModifiedBy = 1;// currentUser.UserId;
                        model.ModifiedDate = DateTime.Now;
                        model.Timestamp = BitConverter.GetBytes(DateTime.Now.Ticks);

                        var customer = context.CustomersMsts.Where(x => x.CustomerId == model.CustomerId).FirstOrDefault();
                        if (customer!=null)
                        {
                            customer.CustomerName = model.CustomerName;
                            customer.MobileNumber = model.MobileNumber;
                            customer.CustomerAddress = model.CustomerAddress;
                            EFobjSave = context.CustomersMsts.Attach(customer);
                            context.Entry(customer).State = EntityState.Modified;
                            Result = "Customer Data Updated Successfully";
                        }

                    }
                    else
                    {
                        model.CreatedBy = 1;///currentUser.UserId;
                        model.CreatedDate = DateTime.Now;
                        model.Timestamp = BitConverter.GetBytes(DateTime.Now.Ticks);
                        var EFObj = AutoMapper.Mapper.Map<CustomerMstDTO, CustomersMst>(model);
                        EFobjSave = context.CustomersMsts.Add(EFObj);
                        Result = "Customer Data Saved Successfully";


                    }

                    context.SaveChanges();
                    return Result;


                }
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
                using (var context = new MJEMEntities())
                {
                    if (id > 0)
                    {
                       
                        var customer = context.CustomersMsts.Where(x => x.CustomerId == id).FirstOrDefault();
                        if (customer != null)
                        {

                            customer.ModifiedBy = 1;// currentUser.UserId;
                            customer.ModifiedDate = DateTime.Now;
                            customer.Timestamp = BitConverter.GetBytes(DateTime.Now.Ticks);
                            customer.IsDeleted= true;
                            var EFobjSave = context.CustomersMsts.Attach(customer);
                            context.Entry(customer).State = EntityState.Modified;
                           
                        }

                    }


                    context.SaveChanges();
                    return ("Customer Data Deleted Successfully");

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
