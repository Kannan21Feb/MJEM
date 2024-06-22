using CSAT.BLL.Contracts.IEmplyoeeBLL;
using CSAT.DAL.Implementations.EmplyoeeDAL;
using CSAT.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAT.BLL.Implementations.EmplyoeeBLL
{
   public class EmplyoeeBLL:IEmplyoeeBLL
    {
        private readonly EmplyoeeDAL _EmplyoeeDAL = new EmplyoeeDAL();

        /// <summary>

        /// <returns></returns>

        public EmplyoeeMstDTO Get(int id)
        {

            try
            {
                return _EmplyoeeDAL.Get(id);



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public string Save(EmplyoeeMstDTO obj)
        {

            try
            {
                return _EmplyoeeDAL.Save(obj);

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
                return _EmplyoeeDAL.Delete(id);



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<EmplyoeeMstDTO> GetAll()
        {

            try
            {
                return _EmplyoeeDAL.GetAll();


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

      
    }
}
