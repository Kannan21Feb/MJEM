using CSAT.BLL.Contracts.ILocationBLL;
using CSAT.DAL.Implementations.LocationDAL;
using CSAT.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSAT.BLL.Implementations.LocationBLL
{
  public class LocationBLL: ILocationBLL
    {
        private readonly LocationDAL _LocationDAL = new LocationDAL();

        /// <summary>

        /// <returns></returns>

        public LocationMstDTO Get(int id)
        {

            try
            {
                return _LocationDAL.Get(id);



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public string Save(LocationMstDTO obj)
        {

            try
            {
                return _LocationDAL.Save(obj);




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
                return _LocationDAL.Delete(id);



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<LocationMstDTO> GetAll()
        {

            try
            {
                return _LocationDAL.GetAll();


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<LocationMstDTO> Load()
        {
            try
            {
                return _LocationDAL.Load();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
