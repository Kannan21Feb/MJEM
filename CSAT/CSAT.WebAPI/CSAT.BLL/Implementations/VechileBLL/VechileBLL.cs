using CSAT.BLL.Contracts.IVechileBLL;
using CSAT.DAL.Implementations.VechileDAL;
using CSAT.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSAT.DTO;

namespace CSAT.BLL.Implementations.VechileBLL
{
  public  class VechileBLL: IVechileBLL

    {

        private readonly VechileDAL _VechileDAL = new VechileDAL();

        /// <summary>

        /// <returns></returns>

        public VechileMstDTO Get(int id)
        {

            try
            {
                return _VechileDAL.Get(id);



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public string Save(VechileMstDTO obj)
        {

            try
            {
                return _VechileDAL.Save(obj);




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
                return _VechileDAL.Delete(id);



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<VechileMstDTO> GetAll()
        {

            try
            {
                return _VechileDAL.GetAll();


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<MJEMSysLovDTO> Load()
        {
            try
            {
                return _VechileDAL.Load();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
